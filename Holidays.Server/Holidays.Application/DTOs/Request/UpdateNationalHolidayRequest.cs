using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Application.DTOs.Request
{
    public class UpdateNationalHolidayRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "O valor precisa ser maior que 0")]
        public int NationalHolidayId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Description { get; set; }
    }
}
