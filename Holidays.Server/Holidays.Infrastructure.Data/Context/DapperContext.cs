using Microsoft.Extensions.Options;
using Holidays.Infrastructure.Data.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Infrastructure.Data.Context
{
    public abstract class DapperContext
    {
        protected SqlConnection DapperConnection { get; }

        public DapperContext(IOptions<ConnectionStringOptions> configuration)
        {
            DapperConnection = new SqlConnection(configuration.Value.SqlConnection);
        }
    }
}
