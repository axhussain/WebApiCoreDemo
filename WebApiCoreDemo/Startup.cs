﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using WebApiCoreDemo.Data;
using WebApiCoreDemo.Data.Entities;

namespace WebApiCoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Actual conn string stored in secrets.json. Ref: Microsoft.Extensions.SecretManager.Tools
            services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString(Configuration.GetConnectionString("DefaultConnection")))
                //Configuration.GetConnectionString(Configuration.GetConnectionString("AzureWebApiDb")))
            );
            services.AddScoped<IWebApiRepository, WebApiRepository>();
            services.AddIdentity<ApiUser, IdentityRole>().AddEntityFrameworkStores<WebApiDbContext>();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Contacts API", Version = "v1" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API v1");
            });
            app.UseMvc();
        }
    }
}
