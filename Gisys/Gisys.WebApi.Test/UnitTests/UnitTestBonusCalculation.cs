using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisys.WebApi.Test.UnitTests
{
    [TestClass]
    public class UnitTestBonusCalculation
    {

        [TestMethod]
        public void Verify_CalculateLoyaltyFactor_Returns_Correct_LoyaltyFactor_For_2_YearsOfEmployment()
        {
            //Arrange 

            //Act
            double loyaltyFactor = Gisys.WebApi.Domain.Helpers.BonusCalculation.CalculateLoyaltyFactor(2);

            //Assert
            Assert.AreEqual(1.2, loyaltyFactor);
        }

        [TestMethod]
        public void Verify_CalculateLoyaltyFactor_Returns_Correct_LoyaltyFactor_For_Half_A_YearOfEmployment()
        {
            //Arrange 

            //Act
            double loyaltyFactor = Gisys.WebApi.Domain.Helpers.BonusCalculation.CalculateLoyaltyFactor(0.5);

            //Assert
            Assert.AreEqual(1, loyaltyFactor);
        }

        [TestMethod]
        public void Verify_CalculateLoyaltyFactor_Returns_Correct_LoyaltyFactor_For_Over_5_YearsOfEmployment()
        {
            //Arrange 

            //Act
            double loyaltyFactor = Gisys.WebApi.Domain.Helpers.BonusCalculation.CalculateLoyaltyFactor(7);

            //Assert
            Assert.AreEqual(1.5, loyaltyFactor);
        }

        [TestMethod]
        public void Verify_CalculateLoyaltyFactor_Returns_Correct_LoyaltyFactor_For_5_YearsOfEmployment()
        {
            //Arrange 

            //Act
            double loyaltyFactor = Gisys.WebApi.Domain.Helpers.BonusCalculation.CalculateLoyaltyFactor(5);

            //Assert
            Assert.AreEqual(1.5, loyaltyFactor);
        }

        [TestMethod]
        public void Verify_CalculateBillingPoints_Returns_Correct_BillingPoint()
        {
            //Arrange 
            double yearOfEmployment = 3;
            int chargedHours = 150;

            //Act

            double loyaltyFactor = Gisys.WebApi.Domain.Helpers.BonusCalculation.CalculateLoyaltyFactor(yearOfEmployment);

            double billingPoint = Gisys.WebApi.Domain.Helpers.BonusCalculation.CalculateBillingPoints(chargedHours, loyaltyFactor);

            //Assert
            Assert.AreEqual(195, billingPoint);
        }

        [TestMethod]
        public void Verify_CalculateBillingPoints_Returns_An_Incorrect_BillingPoint()
        {
            //Arrange 
            double yearOfEmployment = 1;
            int chargedHours = 125;

            //Act
            double loyaltyFactor = Gisys.WebApi.Domain.Helpers.BonusCalculation.CalculateLoyaltyFactor(yearOfEmployment);

            double billingPoint = Gisys.WebApi.Domain.Helpers.BonusCalculation.CalculateBillingPoints(chargedHours, loyaltyFactor);

            //Assert
            Assert.AreNotEqual(130, billingPoint);
        }

        [TestMethod]
        public void Verify_BonusPot_Returns_Correct_Bonus_For_NetResult_Of_100000()
        {
            //Arrange 
            int netResult = 100000;

            //Act
            double bonusPot = Gisys.WebApi.Domain.Helpers.BonusCalculation.BonusPot(netResult);

            //Assert
            Assert.AreEqual(5000, bonusPot);
        }

    }
}
