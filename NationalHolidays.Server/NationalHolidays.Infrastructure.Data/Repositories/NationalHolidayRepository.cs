using Dapper;
using Microsoft.Extensions.Options;
using NationalHolidays.Domain.Interfaces;
using NationalHolidays.Domain.Models;
using NationalHolidays.Infrastructure.Data.Context;
using NationalHolidays.Infrastructure.Data.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalHolidays.Infrastructure.Data.Repositories
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

        public Task<List<NationalHoliday>> List()
        {
            throw new NotImplementedException();
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
