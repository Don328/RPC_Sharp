using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCSharp.Shared.Queries;
public class SampleObjectQuery
{
    public enum Query_Type
    {
        Invalid,
        GetAll,
        ById,
        ByName,
        ByValue,
        ByValue_GT,
        ByValue_LT,
        ByRange,
    }

    public SampleObjectQuery(
        Query_Type queryType)
    {
        QueryType = queryType;
    }


    public Query_Type QueryType { get; }
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int? Value { get; set; }
    public int? GT_Value { get; set; }
    public int? LT_Value { get; set; }
    public string? ErrorMessage { get; set; }
}
