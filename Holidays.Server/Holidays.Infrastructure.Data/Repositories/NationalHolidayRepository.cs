using Dapper;
using Microsoft.Extensions.Options;
using Holidays.Domain.Interfaces;
using Holidays.Domain.Models;
using Holidays.Infrastructure.Data.Context;
using Holidays.Infrastructure.Data.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Infrastructure.Data.Repositories
{
    public class NationalHolidayRepository : DapperContext, INationalHolidayRepository
    {
        #region Constructor
        public NationalHolidayRepository(IOptions<ConnectionStringOptions> configuration) : base(configuration) { }
        #endregion

        #region Public Methods

        public async Task Add(NationalHoliday nationalHoliday)
        {
            await DapperConnection.ExecuteAsync("SP_ADD_NationalHoliday", nationalHoliday, commandType: CommandType.StoredProcedure);
        }

        public Task<NationalHoliday> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<List<NationalHoliday>> GetAll()
        {
            IEnumerable<NationalHoliday> values = await DapperConnection.QueryAsync<NationalHoliday>("SP_LST_NationalHolidays", commandType: CommandType.StoredProcedure);

            return values.ToList();
        }

        public Task Update(int natinalHolidayId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int natinalHolidayId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAll()
        {
            await DapperConnection.ExecuteAsync("SP_DEL_NationalHolidays", commandType: CommandType.StoredProcedure);
        } 
        #endregion
    }
}
