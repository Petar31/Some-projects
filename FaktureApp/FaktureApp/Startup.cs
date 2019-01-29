using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FaktureApp.Models.Fakture;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace FaktureApp
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
            services.AddMvc();
            services.AddDbContext<FakturaContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Connection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            CultureInfo ci = new CultureInfo("sr-Latn-RS");
            List<CultureInfo> podrzane = new List<CultureInfo>
            {
                ci
            };
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.NumberGroupSeparator = ".";
            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
            {
                SupportedCultures = podrzane,
                DefaultRequestCulture = new RequestCulture(ci)
            };
            app.UseRequestLocalization(localizationOptions);


            app.UseStaticFiles();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
