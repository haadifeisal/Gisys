using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.DataTransferObjects
{
    public class ConsultantResponseDto
    {
        public Guid ConsultantId { get; set; }
        public string Name { get; set; }
        public int YearOfEmployment { get; set; }
        public int ChargedHours { get; set; }
    }
}
