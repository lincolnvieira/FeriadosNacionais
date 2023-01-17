using Microsoft.Extensions.Options;
using NationalHolidays.Infrastructure.ExternalService.Context;
using NationalHolidays.Infrastructure.ExternalService.Interfaces;
using NationalHolidays.Infrastructure.ExternalService.Models;
using NationalHolidays.Infrastructure.ExternalService.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NationalHolidays.Infrastructure.ExternalService.Services
{
    public class NationalHolidayExternalService : ExternalServiceContext, INationalHolidayExternalService
    {
        public NationalHolidayExternalService(IOptions<ExternalServiceOptions> configuration) : base(configuration) { }

        public async Task<List<NationalHolidayExternal>> GetNationalHolidaysFromExternalAPI()
        {
            using (var client = new HttpClient())
            {
                List<NationalHolidayExternal> nationalHolidayExternal= new List<NationalHolidayExternal>();
                var response = await client.GetAsync(NationalHolidayAPI);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    nationalHolidayExternal = JsonConvert.DeserializeObject<List<NationalHolidayExternal>>(content);
                }

                return nationalHolidayExternal;
            }
        }
    }
}
