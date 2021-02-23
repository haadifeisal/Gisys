using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.DataTransferObjects
{
    public class ConsultantRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int YearOfEmployment { get; set; }
        [Required]
        public int ChargedHours { get; set; }
    }
}
