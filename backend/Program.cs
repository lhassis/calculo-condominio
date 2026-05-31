using CondominioApi.Data;
using CondominioApi.Configuration;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MapsterMapper;
using CondominioApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
var config = builder.Configuration;

// Add services to the container
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Configure Mapster (TypeAdapterConfig + IMapper)
var mapsterConfig = new TypeAdapterConfig();
MapsterConfig.RegisterMappings(mapsterConfig);
builder.Services.AddSingleton(mapsterConfig);
builder.Services.AddScoped<IMapper, ServiceMapper>();

// Configure database connection
var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") 
    ?? config.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found. " +
        "Set POSTGRES_CONNECTION_STRING environment variable or configure in appsettings.json or User Secrets. " +
        "For development: dotnet user-secrets set \"ConnectionStrings:DefaultConnection\" \"<your-connection-string>\"");
}

builder.Services.Configure<DatabaseConfiguration>(opts =>
{
    opts.ConnectionString = connectionString;
    opts.ValidateConnection = builder.Environment.IsDevelopment();
});

builder.Services.AddDbContext<CondominioDbContext>(options =>
{
    options.UseNpgsql(connectionString, npgsqlOptions =>
    {
        npgsqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null);
        npgsqlOptions.CommandTimeout(30);
    });
    
    if (builder.Environment.IsDevelopment())
    {
        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging(false);
    }
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Validate database connection at startup
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<CondominioDbContext>();
        if (await dbContext.Database.CanConnectAsync())
        {
            app.Logger.LogInformation("✅ Database connection validated successfully");
        }
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "❌ Database connection validation failed");
        if (!builder.Environment.IsProduction())
        {
            throw;
        }
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
