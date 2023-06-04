using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCSharp.Shared;
public class QueryResult<T> where T : class
{
    private readonly Type _type;

    public QueryResult(
        bool success,
        T result,
        string message)
    {
        _type = typeof(T);
        Success = success;
        Result = result;
        Message = message;
    }

    public Type ResultType { get => _type; }
    public bool Success { get; }
    public T Result { get; }
    public string Message { get; }
}
