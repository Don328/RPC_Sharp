using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPCSharp.Server.Data.Fixtures;
using RPCSharp.Shared;
using RPCSharp.Shared.Entities;
using RPCSharp.Shared.Queries;

namespace RPCSharp.Server.Controllers;
[ApiController]
[Route("[controller]")]
public class SampleObjectController : ControllerBase
{
    [HttpPost]
    public QueryResult<SampleObject> Get(SampleObjectQuery query)
    {
        return SampleObjectFixture.ResolveQuery(query);
    }
}
