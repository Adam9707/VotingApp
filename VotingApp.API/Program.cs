using NLog.Web;
using VotingApp.API.Middleware;
using VotingApp.Application;
using VotingApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Logging.ClearProviders();
builder.Host.UseNLog();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddVotingAppPersistenceServices(builder.Configuration);
builder.Services.AddVaotinAppApplication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("WebUIClient", _builder =>
    {
        _builder.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins(builder.Configuration.GetSection("WebUIOrigin").Value);
    });
});
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<LoggingMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors("WebUIClient");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<LoggingMiddleware>();

app.Services.AddVotingAppMigration();

app.Services.SeedVotingAppDb();

app.Run();

