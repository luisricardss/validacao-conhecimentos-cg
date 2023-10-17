using ValidacaoConhecimentoCG.API.Configurations;
using ValidacaoConhecimentoCG.API.Infrastructure.Data.Context;
using ValidacaoConhecimentoCG.API.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.Development.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServicesApi();
builder.Services.RegisterApiDatabase();
builder.Services.RegisterRepositories();
builder.Services.RegisterAppServices();
builder.Services.RegisterHttpClients();

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ConfigurationsDbContext>();
context.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

//app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
