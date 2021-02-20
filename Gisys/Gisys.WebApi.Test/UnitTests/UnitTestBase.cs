using AutoMapper;
using Gisys.WebApi.DataTransferObjects.Configuration;
using Gisys.WebApi.Repository.Gisys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisys.WebApi.Test.UnitTests
{
    public class UnitTestBase
    {
        public readonly GisysContext _context;
        public readonly IMapper _mapper;

        public UnitTestBase()
        {

            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<GisysContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

            _context = new GisysContext(options);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapConfiguration());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            _mapper = mapper;

        }
    }
}
