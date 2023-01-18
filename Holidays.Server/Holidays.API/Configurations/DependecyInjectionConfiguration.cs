using Holidays.Application.Interfaces;
using Holidays.Application.Services;
using Holidays.Domain.Interfaces;
using Holidays.Infrastructure.Data.Options;
using Holidays.Infrastructure.Data.Repositories;
using Holidays.Infrastructure.ExternalService.Interfaces;
using Holidays.Infrastructure.ExternalService.Services;
using System.Configuration;

namespace Holidays.API.Configurations
{
    public static class DependecyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<INationalHolidayService, NationalHolidayService>();
            services.AddScoped<INationalHolidayRepository, NationalHolidayRepository>();
            services.AddScoped<INationalHolidayExternalService, NationalHolidayExternalService>();
        }
    }
}
