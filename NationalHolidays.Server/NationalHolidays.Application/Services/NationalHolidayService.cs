using AutoMapper;
using NationalHolidays.Application.Interfaces;
using NationalHolidays.Domain.Interfaces;
using NationalHolidays.Domain.Models;
using NationalHolidays.Infrastructure.ExternalService.Interfaces;
using NationalHolidays.Infrastructure.ExternalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalHolidays.Application.Services
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
