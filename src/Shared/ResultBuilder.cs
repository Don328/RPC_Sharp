using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCSharp.Shared;
public class ResultBuilder<T> where T : class
{
    private bool _success = false;
    private T _result;
    private string _message = string.Empty;

    public QueryResult<T> Build()
    {
        if (_result is null)
        {
            _success = false;
            _message = "Result was null";
        }

        return new QueryResult<T>(
            _success,
            _result,
            _message);
    }

    public ResultBuilder<T> WithResult(T result)
    {
        _result = result;
        return this;
    }

    public ResultBuilder<T> IsSuccess()
    {
        _success = true;
        _message = "success";
        return this;
    }

    public ResultBuilder<T> IsError(string message) 
    {
        _success = false;
        _message = message;
        return this;
    }

    public ResultBuilder<T> WithMessage(string message)
    {
        _message = message;
        return this;
    }
}
