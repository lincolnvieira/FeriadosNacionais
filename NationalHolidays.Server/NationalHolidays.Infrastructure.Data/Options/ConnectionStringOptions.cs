using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalHolidays.Infrastructure.Data.Options
{
    public class ConnectionStringOptions
    {
        public const string ConnectionString = "ConnectionStrings";
        public string SqlConnection { get; set; }
    }
}
