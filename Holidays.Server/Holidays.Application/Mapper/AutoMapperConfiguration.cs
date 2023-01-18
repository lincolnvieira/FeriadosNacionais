using AutoMapper;
using Holidays.Application.DTOs.Request;
using Holidays.Application.DTOs.Response;
using Holidays.Domain.Models;
using Holidays.Infrastructure.ExternalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Application.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            // Requests
            CreateMap<NationalHoliday, UpdateNationalHolidayRequest>().ReverseMap();

            // Responses
            CreateMap<NationalHoliday, GetNationalHolidaysResponse>().ReverseMap();

            // Modelo API externa
            CreateMap<NationalHoliday, NationalHolidayExternal>().ReverseMap();
        }
    }
}
