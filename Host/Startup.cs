using Domain.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Host
{
    public class Startup
    {
        private const string ORIGIN = "*";
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddCors(options =>
            {
                options.AddPolicy(EnvironmentName.Development, policy =>
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
                
                options.AddPolicy(EnvironmentName.Production, policy =>
                    policy.AllowAnyHeader().WithMethods(HttpMethods.Get).WithOrigins(ORIGIN));
                
            }).AddJsonFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddSingleton(new MongoDbContext("mongodb://localhost"));
        }

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

            app.UseCors(env.IsDevelopment() ? EnvironmentName.Development : EnvironmentName.Production).UseMvc();
        }
    }
}
