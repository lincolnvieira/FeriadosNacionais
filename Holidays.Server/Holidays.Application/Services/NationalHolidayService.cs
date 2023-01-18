using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly INationalHolidayRepository _nationalHolidayRepository;
        private readonly INationalHolidayExternalService _nationalHolidayExternalService;

        public NationalHolidayService(IMapper mapper, INationalHolidayRepository nationalHolidayRepository, INationalHolidayExternalService nationalHolidayExternalService)
        {
            _mapper = mapper;
            _nationalHolidayRepository = nationalHolidayRepository;
            _nationalHolidayExternalService = nationalHolidayExternalService;
        }

        public async Task ResetOriginalDataHolidays()
        {
            List<NationalHolidayExternal> lstNationalHolidayExternal = await _nationalHolidayExternalService.GetNationalHolidaysFromExternalAPI();
            List<NationalHoliday> lstNationalHolidays = _mapper.Map<List<NationalHoliday>>(lstNationalHolidayExternal);

            await _nationalHolidayRepository.DeleteAll();

            await AddNationalHolidays(lstNationalHolidays);
        }

        private async Task AddNationalHolidays(List<NationalHoliday> lstNationalHolidays)
        {
            foreach (var item in lstNationalHolidays)
            {
                await _nationalHolidayRepository.Add(item);
            }
        }
    }
}
