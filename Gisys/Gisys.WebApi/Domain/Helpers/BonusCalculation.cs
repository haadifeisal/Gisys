using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.Domain.Helpers
{
    public class BonusCalculation
    {

        public static double CalculateLoyaltyFactor(double yearOfEmployement)
        {
            if(yearOfEmployement < 1)
            {
                return 1;
            }

            if(yearOfEmployement > 5)
            {
                return 1.5;
            }

            switch (yearOfEmployement)
            {
                case 1:
                    return 1.1;
                case 2:
                    return 1.2;
                case 3:
                    return 1.3;
                case 4:
                    return 1.4;
                case 5:
                    return 1.5;
                default:
                    return 0;
            }
        }

        public static double CalculateBillingPoints(int chargedHours, double loyaltyFactor)
        {
            return chargedHours * loyaltyFactor; // Dk = Tk * Lk
        }

        public static double BonusPot(int netResult)
        {
            return netResult * 0.05;
        }

    }

}
