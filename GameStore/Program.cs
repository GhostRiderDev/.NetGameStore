using app.data;
using Microsoft.EntityFrameworkCore;
using config;
using app.service;


var builder = WebApplication.CreateBuilder(args);

string? datasource = builder.Configuration.GetConnectionString("DBConnString");

builder.Services.AddControllers();
builder.Services.AddSwaggerDocumentation()
                .AddAuthenticationConfig(builder.Configuration)
                .AddEndpointsApiExplorer()
                .AddDbContext<GameStoreContext>(db => db.UseSqlServer(datasource), ServiceLifetime.Singleton)
                .AddProblemDetails()
                .AddCors()
                .AddAuthorization()
                .AddScoped<GameService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(options =>
  {
    options.InjectStylesheet("/styles/style.css");
  });
  app.MapSwagger().RequireAuthorization();
}

app.MapControllers();
app.UseStaticFiles();
app.UseAuthentication(); // Agregar autenticación
app.UseAuthorization();
app.UseStatusCodePages();
app.UseExceptionHandler();
app.UseCors(options =>
{
  options.WithOrigins("*"); // here, front url root path
});

await app.MigrateDbAsync();

app.Run();
