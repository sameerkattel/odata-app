using System;
using Jibble.Application;
using Jibble.InfraStructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.SampleService.Models.TripPin;

namespace Jibble.InfraStructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton(x =>
            {
                var serviceRootUrl = configuration?.GetSection("OdataService")?["ServiceRootUrl"] ?? "https://services.odata.org/V4/TripPinServiceRW/";
                var serviceRoot = new Uri(serviceRootUrl);
                return new DefaultContainer(serviceRoot);
            });

            return services;
        }
    }
}