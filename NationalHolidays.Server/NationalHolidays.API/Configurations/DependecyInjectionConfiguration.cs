using NationalHolidays.Application.Interfaces;
using NationalHolidays.Application.Services;
using NationalHolidays.Domain.Interfaces;
using NationalHolidays.Infrastructure.Data.Options;
using NationalHolidays.Infrastructure.Data.Repositories;
using NationalHolidays.Infrastructure.ExternalService.Interfaces;
using NationalHolidays.Infrastructure.ExternalService.Services;
using System.Configuration;

namespace NationalHolidays.API.Configurations
{
    public static class DependecyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<INationalHolidayService, NationalHolidayService>();
            //services.AddScoped<INationalHolidayRepository, NationalHolidayRepository>();

            services.AddScoped<INationalHolidayExternalService, NationalHolidayExternalService>();
        }
    }
}
