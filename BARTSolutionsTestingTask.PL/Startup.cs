using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.BL.Interfaces;
using BARTSolutionsTestingTask.BL.Services;
using BARTSolutionsTestingTask.DAL;
using BARTSolutionsTestingTask.DAL.Interfaces;
using BARTSolutionsTestingTask.DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BARTSolutionsTestingTask {
	public class Startup {
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services) {
			
			services.AddControllers();
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("BARTSolutionsTestingTaskDB")));
			
			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddScoped<IContactRepository, ContactRepository>();
			services.AddScoped<IIncidentRepository, IncidentRepository>();

			services.AddAutoMapper(typeof(BL.AutoMapper));
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IContactService, ContactService>();
			services.AddScoped<IIncidentService, IncidentService>();

		}
		
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}