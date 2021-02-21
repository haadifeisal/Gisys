using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.DataTransferObjects
{
    public class ConsultantRequestDto
    {
        public string Name { get; set; }
        public int YearOfEmployment { get; set; }
        public int ChargedHours { get; set; }
    }
}
