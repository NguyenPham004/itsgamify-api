using Hangfire;
using its.gamify.api;
using its.gamify.api.Middlewares;
using its.gamify.core.GlobalExceptionHandling;
using its.gamify.core.Services;
using its.gamify.core.SingalR;
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

app.UseHangfireDashboard("/hangfire");

app.MapOpenApi();
app.UseAuthentication();
app.UseAuthorization();

app.MapHub<GameHub>("/gameHub");

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var s3Service = scope.ServiceProvider.GetRequiredService<IS3Service>();
    await s3Service.SetCorsConfigurationAsync();
}

// BackgroundJob.Enqueue<IQuarterService>(service => service.CreateCurrentQuarter());

RecurringJob.AddOrUpdate<IQuarterService>("auto-generate-quarter", service => service.AutoGenerateQuarter(), "0 2 21 * *", new RecurringJobOptions
{
    TimeZone = TimeZoneInfo.Utc,
    MisfireHandling = MisfireHandlingMode.Relaxed
});

app.Run();
