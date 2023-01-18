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
using static Dapper.SqlMapper;

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
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Date", nationalHoliday.Date);
            dynamicParameters.Add("@Title", nationalHoliday.Title);
            dynamicParameters.Add("@Description", nationalHoliday.Description);
            dynamicParameters.Add("@Legislation", nationalHoliday.Legislation);
            dynamicParameters.Add("@Type", nationalHoliday.Type);
            dynamicParameters.Add("@StartTime", nationalHoliday.StartTime);
            dynamicParameters.Add("@EndTime", nationalHoliday.EndTime);

            await DapperConnection.ExecuteAsync("SP_ADD_NationalHoliday", dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<NationalHoliday> GetById(int nationalHolidayId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@NationalHolidayId", nationalHolidayId);

            return await DapperConnection.QueryFirstOrDefaultAsync<NationalHoliday>("SP_GET_NationalHolidayById", dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<NationalHoliday>> GetAll()
        {
            return (await DapperConnection.QueryAsync<NationalHoliday>("SP_LST_NationalHolidays", commandType: CommandType.StoredProcedure)).ToList();
        }

        public async Task Update(NationalHoliday nationalHoliday)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@NationalHolidayId", nationalHoliday.NationalHolidayId);
            dynamicParameters.Add("@Description", nationalHoliday.Description);

            await DapperConnection.ExecuteAsync("SP_UPD_NationalHoliday", dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(int nationalHolidayId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@NationalHolidayId", nationalHolidayId);

            await DapperConnection.ExecuteAsync("SP_DEL_NationalHolidayById", dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAll()
        {
            await DapperConnection.ExecuteAsync("SP_DEL_NationalHolidays", commandType: CommandType.StoredProcedure);
        } 
        #endregion
    }
}
