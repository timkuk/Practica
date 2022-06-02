using System;
using Booking.DAL.Interfaces;
using Booking.DAL.MongoConfig;
using Booking.DAL.Repositories;
using Booking.Domain.Entities.UserAggregate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Booking.DAL.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDal(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));
            services.AddTransient(provider => provider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            
            var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
                (
                    mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName
                );
            
            services.AddTransient<IAdvertisementRepository, AdvertisementRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            return services;
        }
    }
}
