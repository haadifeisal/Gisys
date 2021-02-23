using Gisys.WebApi.DataTransferObjects;
using Gisys.WebApi.Repository.Gisys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.Domain.Services.Interfaces
{
    public interface IConsultantService
    {
        Consultant GetConsultant(Guid consultantId);
        ICollection<Consultant> GetConsultantCollection();
        Consultant CreateConsultant(ConsultantRequestDto consultantRequestDto);
        Consultant UpdateConsultant(Guid consultantId, ConsultantRequestDto consultantRequestDto);
        bool DeleteConsultant(Guid consultantId);
        double SumOfBillingPoints();
        double GetConsultantShareOfBonusPot(Guid consultantId);
        double GetConsultantBonus(Guid consultantId);
    }
}
