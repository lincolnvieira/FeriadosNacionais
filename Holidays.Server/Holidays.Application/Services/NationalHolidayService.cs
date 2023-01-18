using AutoMapper;
using Holidays.Application.DTOs.Response;
using Holidays.Application.Interfaces;
using Holidays.Domain.Interfaces;
using Holidays.Domain.Models;
using Holidays.Infrastructure.ExternalService.Interfaces;
using Holidays.Infrastructure.ExternalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Application.Services
{
    public class NationalHolidayService : INationalHolidayService
    {
        #region Declarations
        private readonly IMapper _mapper;
        private readonly INationalHolidayRepository _nationalHolidayRepository;
        private readonly INationalHolidayExternalService _nationalHolidayExternalService; 
        #endregion

        #region Constructor
        public NationalHolidayService(IMapper mapper, INationalHolidayRepository nationalHolidayRepository, INationalHolidayExternalService nationalHolidayExternalService)
        {
            _mapper = mapper;
            _nationalHolidayRepository = nationalHolidayRepository;
            _nationalHolidayExternalService = nationalHolidayExternalService;
        }
        #endregion

        #region Public Methods
        public async Task<List<GetNationalHolidaysResponse>> GetAllNationalHoliday()
        {
            List<NationalHoliday> lstNationalHoliday = await _nationalHolidayRepository.GetAll();

            List<GetNationalHolidaysResponse> lstGetNationalHolidaysResponse = _mapper.Map<List<GetNationalHolidaysResponse>>(lstNationalHoliday);

            return lstGetNationalHolidaysResponse;
        }

        public async Task ResetOriginalDataHolidays()
        {
            List<NationalHolidayExternal> lstNationalHolidayExternal = await _nationalHolidayExternalService.GetNationalHolidaysFromExternalAPI();

            List<NationalHoliday> lstNationalHolidays = _mapper.Map<List<NationalHoliday>>(lstNationalHolidayExternal);

            await _nationalHolidayRepository.DeleteAll();

            await AddNationalHolidays(lstNationalHolidays);
        }
        #endregion

        #region Private Methods
        private async Task AddNationalHolidays(List<NationalHoliday> lstNationalHolidays)
        {
            foreach (var item in lstNationalHolidays)
            {
                await _nationalHolidayRepository.Add(item);
            }
        } 
        #endregion
    }
}
