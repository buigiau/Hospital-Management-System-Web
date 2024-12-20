using ServiceContracts;
using HospitalManagementSystem;
using Entites;
using Microsoft.EntityFrameworkCore;
using Serilog;
using HospitalManagementSystem.UI.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) => {

	loggerConfiguration
	.ReadFrom.Configuration(context.Configuration) //read configuration settings from built-in IConfiguration
	.ReadFrom.Services(services); //read out current app's services and make them available to serilog
});

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Error");
	app.UseExceptionHandlingMiddleware();
}

app.UseHsts();
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();


app.UseHttpLogging();

if (builder.Environment.IsEnvironment("Test") == false)
	Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapStaticAssets();

/*app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=User}/{action=Login}/{id?}");
});*/
app.UseEndpoints(endpoints => {
	endpoints.MapControllerRoute(
	 name: "areas",
	 pattern: "{area:exists}/{controller=Home}/{action=Index}");

	//Admin/Home/Index
	//Admin

	endpoints.MapControllerRoute(
	 name: "default",
	 pattern: "{controller=User}/{action=Login}/{id?}"
	 );
});

app.Run();
