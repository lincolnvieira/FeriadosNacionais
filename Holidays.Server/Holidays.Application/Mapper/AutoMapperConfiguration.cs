using AutoMapper;
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
