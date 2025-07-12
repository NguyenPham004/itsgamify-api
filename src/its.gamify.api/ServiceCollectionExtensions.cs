using its.gamify.api.Middlewares;
using its.gamify.api.Validations;
using its.gamify.core.GlobalExceptionHandling;
using its.gamify.core.Mappers;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Models;
using its.gamify.infras.Datas;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scrutor;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace its.gamify.api;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add Core Services
    /// Todo: Swagger Generation
    /// </summary>
    /// <param name="services"></param>
    /// <param name="appSetting"></param>
    /// <returns></returns>
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
        AppSetting appSetting)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "ITS-Gamify", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            opt.IncludeXmlComments(xmlPath);
            opt.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Bearer Generated JWT-Token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"

            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = JwtBearerDefaults.AuthenticationScheme
                                    },
                                    Scheme = "oauth2",
                                    Name = "Bearer",
                                    In = ParameterLocation.Header,
                                }, Array.Empty<string>()
                            }
                        });
        });

        services.AddHttpContextAccessor();

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
            appSetting.ConnectionStrings["DefaultConnection"] ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.Scan(scan =>
        {
            scan.FromAssemblies(getAssemblies())
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime();
        });
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("VERYSTRONGPASSWORD_CHANGEMEIFYOUNEED")),
                ValidateIssuer = true,
                ValidIssuer = "its.gamify",
                ValidAudience = "its.gamify.client",
                ValidateAudience = true,
                ValidateLifetime = true,
            };
        });

        services.AddAutoMapper(typeof(MapperConfigurationProfile).Assembly);

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        services.AddControllers(options =>
        {
            options.ModelBinderProviders.Insert(0, new OrderParamListBinderProvider());
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.SnakeCaseLower;
        });

        services.AddControllers();

        services.AddRouting(x => x.LowercaseUrls = true);

        services.AddHttpClient();

        services.AddSingleton<GlobalErrorHandlingMiddleware>();

        services.AddSingleton(appSetting);

        services.AddOpenApi();

        services.AddSingleton<GlobalErrorHandlingMiddleware>();
        services.AddSingleton<PerformanceMiddleware>();
        services.AddSingleton<Stopwatch>();

        return services;
    }
    private static Assembly[] getAssemblies()
        => [AssemblyReference.Assembly, infras.AssemblyReference.Assembly, core.AssemblyReference.Assembly];

}