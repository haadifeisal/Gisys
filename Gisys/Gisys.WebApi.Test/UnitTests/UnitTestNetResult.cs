using Gisys.WebApi.Domain.Services;
using Gisys.WebApi.Repository.Gisys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gisys.WebApi.Test.UnitTests
{
    [TestClass]
    public class UnitTestNetResult : UnitTestBase
    {

        [TestMethod]
        public void Verify_GetNetResult_Returns_100000()
        {
            //Arrange
            var newNetResult = new NetResult
            {
                NetResultId = Guid.NewGuid(),
                Net = 100000
            };

            _context.Add(newNetResult);
            _context.SaveChanges();

            var netResultService = new NetResultService(_context);

            //Act
            var netResult = netResultService.GetNetResult();

            //Assert
            Assert.IsNotNull(netResult);
            Assert.AreEqual(100000, netResult.Net);
        }

        [TestMethod]
        public void Verify_CreateNetResult_Returns_The_Created_NetResult_Object()
        {
            //Arrange

            var netResultService = new NetResultService(_context);

            //Act
            var netResult = netResultService.CreateNetResult(100000);

            //Assert
            Assert.IsNotNull(netResult);
            Assert.AreEqual(100000, netResult.Net);
        }

        [TestMethod]
        public void Verify_CreateNetResult_Returns_Null_When_NetResult_Already_Exists()
        {
            //Arrange
            var newNetResult = new NetResult
            {
                NetResultId = Guid.NewGuid(),
                Net = 100000
            };

            _context.Add(newNetResult);
            _context.SaveChanges();

            var netResultService = new NetResultService(_context);

            //Act
            var netResult = netResultService.CreateNetResult(100000);

            //Assert
            Assert.IsNull(netResult);
        }

        [TestMethod]
        public void Verify_UpdateNetResult_Returns_The_Updated_NetResult_Object()
        {
            //Arrange
            var newNetResult = new NetResult
            {
                NetResultId = Guid.NewGuid(),
                Net = 100000
            };

            _context.Add(newNetResult);
            _context.SaveChanges();

            var netResultService = new NetResultService(_context);

            //Act
            var netResult = netResultService.UpdateNetResult(newNetResult.NetResultId, 150000);

            //Assert
            Assert.IsNotNull(netResult);
            Assert.AreEqual(newNetResult.NetResultId, netResult.NetResultId);
            Assert.AreEqual(150000, netResult.Net);
        }

        [TestMethod]
        public void Verify_UpdateNetResult_Returns_Null_When_NetResult_Is_Not_Found()
        {
            //Arrange
            var newNetResult = new NetResult
            {
                NetResultId = Guid.NewGuid(),
                Net = 100000
            };

            _context.Add(newNetResult);
            _context.SaveChanges();

            var netResultService = new NetResultService(_context);

            //Act
            var netResult = netResultService.UpdateNetResult(Guid.NewGuid(), 150000);

            //Assert
            Assert.IsNull(netResult);
        }

    }
}
