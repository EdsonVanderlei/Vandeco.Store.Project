using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace VandecoStore.API.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection ConfigureWebApi(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
            });

            return services;
        }
    }
}
