using AutoMapper;
using Gisys.WebApi.Domain.Services.Interfaces;
using Gisys.WebApi.Repository.Gisys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.Domain.Services
{
    public class ConsultantService : IConsultantService
    {

        private readonly GisysContext _context;
        private readonly IMapper _mapper;

        public ConsultantService(GisysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Consultant GetConsultant(Guid consultantId)
        {
            var consultant = _context.Consultants.AsNoTracking().FirstOrDefault(x => x.ConsultantId == consultantId);

            return consultant;
        }

        public double SumOfBillingPoints()
        {
            double sum = 0;

            var consultantCollection = _context.Consultants.AsNoTracking().ToList();

            foreach(var consultant in consultantCollection)
            {
                sum += Helpers.BonusCalculation.CalculateBillingPoints(consultant.ChargedHours, Helpers.BonusCalculation.CalculateLoyaltyFactor(consultant.YearOfEmployment));
            }

            return sum;
        }

        public double GetConsultantShareOfBonusPot(Guid consultantId)
        {
            var consultant = _context.Consultants.AsNoTracking().FirstOrDefault(x => x.ConsultantId == consultantId);

            if(consultant == null)
            {
                return 0;
            }

            double billingPoint = Helpers.BonusCalculation.CalculateBillingPoints(consultant.ChargedHours, Helpers.BonusCalculation.CalculateLoyaltyFactor(consultant.YearOfEmployment));

            double Bk = billingPoint/SumOfBillingPoints(); // Bk = Dk1/Dt

            return Bk;
        }

        public double GetConsultantBonus(Guid consultantId, int netResult)
        {
            var consultant = _context.Consultants.AsNoTracking().FirstOrDefault(x => x.ConsultantId == consultantId);

            if (consultant == null)
            {
                return 0;
            }

            return Helpers.BonusCalculation.BonusPot(netResult) * GetConsultantShareOfBonusPot(consultant.ConsultantId);
        }

    }
}
