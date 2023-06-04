using RPCSharp.Server.Data.Repos;
using RPCSharp.Shared;
using RPCSharp.Shared.Entities;
using RPCSharp.Shared.Queries;

namespace RPCSharp.Server.Data.Fixtures;

internal static class SampleObjectFixture<T> where T : class
{
    internal static QueryResult<T> ResolveQuery(SampleObjectQuery query)
    {
        var type = nameof(T);

        switch (type)
        {
            case nameof(SampleObject):
                break;
            case nameof(IEnumerable<SampleObject>):
                break;
        }

        T result;
        var repo = new SampleObjectRepo().Values;
        switch (query.QueryType)
        {
            case SampleObjectQuery.Query_Type.Invalid:
                return new ResultBuilder<T>()
                    .IsError("Query Type 'Invalid'")
                    .Build();
            case SampleObjectQuery.Query_Type.GetAll:
                return new ResultBuilder<T>()
                    .IsSuccess()
                    .WithResult(result)
                    .Build();
                
                return repo;
            case SampleObjectQuery.Query_Type.ById: 
                return (from o in repo
                        where o.Id == query.Id
                        select o).ToList();
            case SampleObjectQuery.Query_Type.ByName: 
                return (from o in repo
                        where o.Name == query.Name
                        select o).ToList();
            case SampleObjectQuery.Query_Type.ByValue:
                return (from o in repo
                        where o.Value == query.Value
                        select o).ToList();
            case SampleObjectQuery.Query_Type.ByValue_GT:
                return (from o in repo
                        where o.Value > query.GT_Value
                        select o).ToList();
            case SampleObjectQuery.Query_Type.ByValue_LT:
                return (from o in repo
                        where o.Value < query.LT_Value
                        select o).ToList();
            case SampleObjectQuery.Query_Type.ByRange:
                return (from o in repo
                        where o.Value > query.GT_Value
                        && o.Value < query.LT_Value
                        select o).ToList();
        }

        return repo;
    }
}
