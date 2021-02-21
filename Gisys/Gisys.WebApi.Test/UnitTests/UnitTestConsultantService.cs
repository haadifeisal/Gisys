using Gisys.WebApi.DataTransferObjects;
using Gisys.WebApi.Domain.Services;
using Gisys.WebApi.Repository.Gisys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisys.WebApi.Test.UnitTests
{
    [TestClass]
    public class UnitTestConsultantService : UnitTestBase
    {
        [TestMethod]
        public void Verify_GetConsultant_Returns_Correct_Consultant()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "James",
                ChargedHours = 210,
                YearOfEmployment = 4
            };

            _context.Consultants.Add(newConsultant);
            _context.SaveChanges();

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultant = consultantService.GetConsultant(newConsultant.ConsultantId);

            //Assert
            Assert.IsNotNull(consultant);
            Assert.AreEqual(newConsultant.Name, consultant.Name);
        }

        [TestMethod]
        public void Verify_GetConsultant_Returns_Null_When_Consultant_Doesnt_Exists()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "James",
                ChargedHours = 210,
                YearOfEmployment = 4
            };

            _context.Consultants.Add(newConsultant);
            _context.SaveChanges();

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultant = consultantService.GetConsultant(Guid.NewGuid());

            //Assert
            Assert.IsNull(consultant);
        }

        [TestMethod]
        public void Verify_GetConsultantCollection_Returns_A_Collection_Of_2_Consultants()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "James",
                ChargedHours = 210,
                YearOfEmployment = 4
            };
            _context.Consultants.Add(newConsultant);

            var newConsultant2 = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "Brasi",
                ChargedHours = 115,
                YearOfEmployment = 1
            };

            _context.Consultants.Add(newConsultant2);
            _context.SaveChanges();

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultantCollection = consultantService.GetConsultantCollection();

            //Assert
            Assert.AreEqual(2,consultantCollection.Count);
        }

        [TestMethod]
        public void Verify_GetConsultantCollection_Returns_An_Empty_Collection()
        {
            //Arrange
            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultantCollection = consultantService.GetConsultantCollection();

            //Assert
            Assert.AreEqual(0, consultantCollection.Count);
        }

        [TestMethod]
        public void Verify_CreateConsultant_Returns_The_Created_Consultant_Object()
        {
            //Arrange
            var consultantRequestDto = new ConsultantRequestDto
            {
                Name = "James",
                ChargedHours = 210,
                YearOfEmployment = 4
            };

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultant = consultantService.CreateConsultant(consultantRequestDto);

            //Assert
            Assert.IsNotNull(consultant);
            Assert.AreEqual(consultantRequestDto.Name, consultant.Name);
        }

        [TestMethod]
        public void Verify_UpdateConsultant_Returns_The_Updated_Consultant_Object()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "Brasi",
                ChargedHours = 210,
                YearOfEmployment = 1
            };

            _context.Consultants.Add(newConsultant);
            _context.SaveChanges();

            var consultantRequestDto = new ConsultantRequestDto
            {
                Name = "James",
                ChargedHours = 210,
                YearOfEmployment = 4
            };

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultant = consultantService.UpdateConsultant(newConsultant.ConsultantId, consultantRequestDto);

            //Assert
            Assert.IsNotNull(consultant);
            Assert.AreEqual(newConsultant.Name, consultant.Name);
            Assert.AreEqual(newConsultant.YearOfEmployment, consultant.YearOfEmployment);
        }

        [TestMethod]
        public void Verify_UpdateConsultant_Returns_Null_When_Consultant_Doesnt_Exists()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "Brasi",
                ChargedHours = 210,
                YearOfEmployment = 1
            };

            _context.Consultants.Add(newConsultant);
            _context.SaveChanges();

            var consultantRequestDto = new ConsultantRequestDto
            {
                Name = "James",
                ChargedHours = 210,
                YearOfEmployment = 4
            };

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultant = consultantService.UpdateConsultant(Guid.NewGuid(), consultantRequestDto);

            //Assert
            Assert.IsNull(consultant);
        }

        [TestMethod]
        public void Verify_DeleteConsultant_Returns_The_True()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "Brasi",
                ChargedHours = 115,
                YearOfEmployment = 1
            };

            _context.Consultants.Add(newConsultant);
            _context.SaveChanges();

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultant = consultantService.DeleteConsultant(newConsultant.ConsultantId);

            //Assert
            Assert.IsTrue(consultant);
        }

        [TestMethod]
        public void Verify_DeleteConsultant_Returns_The_False_When_Consultant_Doesnt_Exist()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "Brasi",
                ChargedHours = 115,
                YearOfEmployment = 1
            };

            _context.Consultants.Add(newConsultant);
            _context.SaveChanges();

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultant = consultantService.DeleteConsultant(Guid.NewGuid());

            //Assert
            Assert.IsFalse(consultant);
        }

        [TestMethod]
        public void Verify_SumOfBillingPoints_Returns_371()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "James",
                ChargedHours = 150,
                YearOfEmployment = 3
            };
            _context.Consultants.Add(newConsultant);

            var newConsultant2 = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "Morgan",
                ChargedHours = 160,
                YearOfEmployment = 1
            };

            _context.Consultants.Add(newConsultant2);
            _context.SaveChanges();

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var sumOfBillingPoints = consultantService.SumOfBillingPoints();

            //Assert
            Assert.AreEqual(371, sumOfBillingPoints);
        }

        [TestMethod]
        public void Verify_GetConsultantShareOfBonusPot_Returns_52_Percent()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "James",
                ChargedHours = 150,
                YearOfEmployment = 3
            };
            _context.Consultants.Add(newConsultant);

            var newConsultant2 = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "Morgan",
                ChargedHours = 160,
                YearOfEmployment = 1
            };

            _context.Consultants.Add(newConsultant2);
            _context.SaveChanges();

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var Bk = consultantService.GetConsultantShareOfBonusPot(newConsultant.ConsultantId);

            //Assert
            Assert.AreEqual(52.6, Math.Round(Bk*100, 1));
        }

        [TestMethod]
        public void Verify_GetConsultantShareOfBonusPot_Returns_0_When_Consultant_Is_Not_Found()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "James",
                ChargedHours = 150,
                YearOfEmployment = 3
            };
            _context.Consultants.Add(newConsultant);

            var newConsultant2 = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "Morgan",
                ChargedHours = 160,
                YearOfEmployment = 1
            };

            _context.Consultants.Add(newConsultant2);
            _context.SaveChanges();

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var Bk = consultantService.GetConsultantShareOfBonusPot(Guid.NewGuid());

            //Assert
            Assert.AreEqual(0,Bk);
        }

        [TestMethod]
        public void Verify_GetConsultantBonus_Returns_Correct_Consultant_Bonuses_For_Consultant1_And_Consultant2()
        {
            //Arrange
            var newConsultant = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "James",
                ChargedHours = 150,
                YearOfEmployment = 3
            };
            _context.Consultants.Add(newConsultant);

            var newConsultant2 = new Consultant
            {
                ConsultantId = Guid.NewGuid(),
                Name = "Morgan",
                ChargedHours = 160,
                YearOfEmployment = 1
            };

            _context.Consultants.Add(newConsultant2);
            _context.SaveChanges();

            var consultantService = new ConsultantService(_context, _mapper);

            //Act
            var consultantBonus1 = consultantService.GetConsultantBonus(newConsultant.ConsultantId, 100000);
            var consultantBonus2 = consultantService.GetConsultantBonus(newConsultant2.ConsultantId, 100000);

            //Assert
            Assert.AreEqual(2628, consultantBonus1);
            Assert.AreEqual(2372, consultantBonus2);
        }

    }
}
