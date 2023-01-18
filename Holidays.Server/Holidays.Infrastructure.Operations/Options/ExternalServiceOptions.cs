using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Infrastructure.ExternalService.Options
{
    public class ExternalServiceOptions
    {
        public const string ExternalService = "ExternalService";
        public string UrlNationalHolidayAPI { get; set; }
    }
}
