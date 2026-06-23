var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AuthAccessOptions>(
    builder.Configuration.GetSection(AuthAccessOptions.SectionName));
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        var origins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
            ?? [];

        policy
            .WithOrigins(origins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("Frontend");

// Google authentication will be added here later. Keep authorization in the
// pipeline now so controller policies can be introduced without reshaping it.
app.UseAuthorization();

app.MapControllers();

app.Run();

public sealed class AuthAccessOptions
{
    public const string SectionName = "AuthAccess";

    public string[] AllowedEmails { get; init; } = [];
}
