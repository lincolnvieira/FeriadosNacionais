using AutoMapper;
using NationalHolidays.Domain.Models;
using NationalHolidays.Infrastructure.ExternalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalHolidays.Application.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            MapeamentosRequest();
            MapeamentosResponse();
        }

        private void MapeamentosRequest()
        {
            
        }

        private void MapeamentosResponse()
        {
            CreateMap<NationalHoliday, NationalHolidayExternal>().ReverseMap();
        }
    }
}
