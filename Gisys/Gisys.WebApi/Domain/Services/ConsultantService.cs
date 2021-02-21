using AutoMapper;
using Gisys.WebApi.DataTransferObjects;
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

        public ICollection<Consultant> GetConsultantCollection()
        {
            var consultantCollection = _context.Consultants.AsNoTracking().ToList();

            return consultantCollection;
        }

        public Consultant CreateConsultant(ConsultantRequestDto consultantRequestDto)
        {
            var newConsultant = _mapper.Map<Consultant>(consultantRequestDto);
            newConsultant.ConsultantId = Guid.NewGuid();

            _context.Consultants.Add(newConsultant);
            _context.SaveChanges();

            return newConsultant;
        }

        public Consultant UpdateConsultant(Guid consultantId, ConsultantRequestDto consultantRequestDto)
        {
            var consultant = _context.Consultants.FirstOrDefault(x => x.ConsultantId == consultantId);

            if(consultant == null)
            {
                return null;
            }

            consultant.Name = consultantRequestDto.Name;
            consultant.YearOfEmployment = consultantRequestDto.YearOfEmployment;
            consultant.ChargedHours = consultantRequestDto.ChargedHours;

            _context.SaveChanges();

            return consultant;

        }

        public bool DeleteConsultant(Guid consultantId)
        {
            var consultant = _context.Consultants.FirstOrDefault(x => x.ConsultantId == consultantId);

            if (consultant == null)
            {
                return false;
            }

            _context.Consultants.Remove(consultant);

            if(_context.SaveChanges() == 1)
            {
                return true;
            }

            return false;
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

            var consultantBonus = Helpers.BonusCalculation.BonusPot(netResult) * GetConsultantShareOfBonusPot(consultant.ConsultantId);

            return Math.Round(consultantBonus, 0);
        }

    }
}
