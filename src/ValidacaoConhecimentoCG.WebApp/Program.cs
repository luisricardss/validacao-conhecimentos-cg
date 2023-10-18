using ValidacaoConhecimentoCG.WebApp.ExternalServices.API;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName ?? "Development";
builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages() ;
builder.Services.AddHttpClient<IApiClient, ApiClient>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Conta/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Conta}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
