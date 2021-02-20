using System;
using System.Collections.Generic;

#nullable disable

namespace Gisys.WebApi.Repository.Gisys
{
    public partial class Consultant
    {
        public Guid ConsultantId { get; set; }
        public string Name { get; set; }
        public int YearOfEmployment { get; set; }
        public int ChargedHours { get; set; }
    }
}
