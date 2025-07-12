using its.gamify.api;
using its.gamify.api.Middlewares;
using its.gamify.core.GlobalExceptionHandling;
using its.gamify.domains.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration
    .Get<AppSetting>() ?? throw new Exception("Null configuration");

builder.Services.AddCoreServices(appSetting: configuration);

builder.Configuration.AddUserSecrets<Program>();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.UseCors("AllowAll");

app.UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseMiddleware<PerformanceMiddleware>();


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
app.MapOpenApi();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
