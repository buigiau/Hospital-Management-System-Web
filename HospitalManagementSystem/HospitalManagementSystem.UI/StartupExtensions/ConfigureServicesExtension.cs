using HospitalManagementSystem.Core.Domain.IndentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Entites;
using HospitalManagementSystem.Core.Domain.RepositoryContracts;
using HospitalManagementSystem.Core.ServiceContracts;
using HospitalManagementSystem.Core.Services;
using HospitalManagementSystem.Infrastucture.Repositories;

namespace HospitalManagementSystem.UI.StartupExtensions
{
	public static class ConfigureServicesExtension
	{
		public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration) 
		{
			services.AddControllersWithViews(options =>
			{
				//options.Filters.Add<ResponseHeaderActionFilter>(5);

				/*var logger = services.BuildServiceProvider().GetRequiredService<ILogger<ResponseHeaderActionFilter>>();

                options.Filters.Add(new ResponseHeaderActionFilter(logger)
                {
                    Key = "My-Key-From-Global",
                    Value = "My-Value-From-Global",
                    Order = 2
                });*/

				options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

			});

			//Denpendency Injection
			services.AddScoped<IPatientRepository, PatientRepository>();
			services.AddScoped<IPatientService, PatientService>();
			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<IDepartmentService, DepartmentService>();



			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});
			//Enable Identity in this project
			services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
			{
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireDigit = true;
				options.Password.RequiredUniqueChars = 3; //Eg: AB12AB (unique characters are A,B,1,2)
			})
			 .AddEntityFrameworkStores<ApplicationDbContext>()

			 .AddDefaultTokenProviders()

			 .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()


			 .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();

			services.AddAuthorization(options =>
			{
				options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //enforces authoriation policy (user must be authenticated) for all the action methods

				options.AddPolicy("NotAuthorized", policy =>
				{
					policy.RequireAssertion(context =>
					{
						return !context.User.Identity.IsAuthenticated;
					});
				});
			});

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/User/Login";
			});

			services.AddHttpLogging(options =>
			{
				options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestProperties | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders;

			});
			services.AddHttpContextAccessor();

			return services;
		}

	}
}
