using System.Reflection;
using Booking.BLL.CQRS.PipelineBehaviours;
using Booking.BLL.Interfaces;
using Booking.BLL.Services;
using Booking.DAL.DI;
using Booking.Prepopulator.Interfaces;
using Booking.Prepopulator.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Booking.BLL.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureBll(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDal(configuration);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPrepopulatorService, PrepopulatorService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}
