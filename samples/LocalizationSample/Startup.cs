using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using My.AspNetCore.Localization.Json;

namespace LocalizationSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddViewLocalization();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IStringLocalizer<Startup> localizer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("ar-YE")
            };

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            options.RequestCultureProviders.Insert(0, new JsonRequestCultureProvider());
            app.UseRequestLocalization(options);

            app.UseMvc();
        }
    }
}
