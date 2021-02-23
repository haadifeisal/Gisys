using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.DataTransferObjects
{
    public class NetResultRequestDto
    {
        [Required]
        public int Net { get; set; }
    }
}
