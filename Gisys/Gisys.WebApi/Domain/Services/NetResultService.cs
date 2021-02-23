using Gisys.WebApi.Domain.Services.Interfaces;
using Gisys.WebApi.Repository.Gisys;
using System;
using System.Linq;

namespace Gisys.WebApi.Domain.Services
{
    public class NetResultService : INetResultService
    {
        private readonly GisysContext _context;

        public NetResultService(GisysContext context)
        {
            _context = context;
        }

        public NetResult GetNetResult()
        {
            var netResult = _context.NetResults.FirstOrDefault();

            if(netResult == null)
            {
                return null;
            }

            return netResult;
        }

        public NetResult CreateNetResult(int netResult)
        {
            var netResultExists = _context.NetResults.Any();
            if (netResultExists) 
            {
                return null;
            }

            var newNetResult = new NetResult
            {
                NetResultId = Guid.NewGuid(),
                Net = netResult
            };

            _context.NetResults.Add(newNetResult);
            _context.SaveChanges();

            return newNetResult;
        }

        public NetResult UpdateNetResult(Guid netResultId, int net)
        {
            var netResult = _context.NetResults.FirstOrDefault(x => x.NetResultId == netResultId);
            if (netResult == null)
            {
                return null;
            }

            netResult.Net = net;
            _context.SaveChanges();

            return netResult;
        }

    }
}
