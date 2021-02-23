using Gisys.WebApi.Repository.Gisys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.Domain.Services.Interfaces
{
    public interface INetResultService
    {
        NetResult GetNetResult();
        NetResult CreateNetResult(int netResult);
        NetResult UpdateNetResult(Guid netResultId, int net);
    }
}
