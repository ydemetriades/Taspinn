using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Taspin.Api.Options;
using Taspin.Api.Services;
using Taspin.Data;
using Taspin.Data.Dac;

namespace Taspin.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            string taspinDbConnString = Configuration.GetValue<string>("AppSettings:TaspinDatabaseConnectionString");

            services.AddSingleton<DatabaseOptions>(tt =>
            {
                return new DatabaseOptions(taspinDbConnString);
            });

            services.AddScoped<ShoppingListDac>();
            services.AddScoped<DisposeListDac>();
            services.AddScoped<UsersDac>();
            services.AddScoped<ItemsDac>();

            services.AddScoped<IDisposeListService, DisposeListService>();
            services.AddScoped<IShoppingListService, ShoppingListService>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
