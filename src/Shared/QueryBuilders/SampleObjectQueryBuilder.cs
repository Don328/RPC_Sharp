using RPCSharp.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPCSharp.Shared.QueryBuilders;
public class SampleObjectQueryBuilder
{
    private SampleObjectQuery _query;

    public SampleObjectQueryBuilder (
        SampleObjectQuery.Query_Type queryType)
    {
        _query = new SampleObjectQuery(queryType);
    }
    public SampleObjectQuery Build(out bool success)
    {
        if (_query == null)
        {
            success = false;
            return new SampleObjectQuery(0);
        }
        
        success = IsValid(_query);
        return _query;
    }

    public SampleObjectQueryBuilder GetAll()
    {
        return this;
    }

    public SampleObjectQueryBuilder ById(int id)
    {
        _query.Id = id;
        return this;
    }

    public SampleObjectQueryBuilder ByName(string name)
    {
        _query.Name = name;
        return this;
    }

    public SampleObjectQueryBuilder ByValue(int value)
    {
        _query.Value = value;
        return this;
    }

    public SampleObjectQueryBuilder ByValue_GT(int value)
    {
        _query.GT_Value = value;
        return this;
    }

    public SampleObjectQueryBuilder ByValue_LT(int value)
    {
        _query.LT_Value = value;
        return this;
    }

    public SampleObjectQueryBuilder ByRange(int greaterThan, int lessThan)
    {
        _query.GT_Value = greaterThan;
        _query.LT_Value = lessThan;
        return this;
    }

    private static bool IsValid(SampleObjectQuery query)
    {
        switch (query.QueryType)
        {
            case SampleObjectQuery.Query_Type.Invalid:
                return false;
            case SampleObjectQuery.Query_Type.GetAll:
                return true;
            case SampleObjectQuery.Query_Type.ById:
                if (query.Id < 1)
                {
                    query.ErrorMessage = "Get by Id attempted. Id must not be null";
                    return false;
                }
                return true;
            case SampleObjectQuery.Query_Type.ByName:
                if (string.IsNullOrEmpty(query.Name))
                {
                    query.ErrorMessage = "Get by Name attempted. Name must not be null";
                    return false;
                }
                return true;
            case SampleObjectQuery.Query_Type.ByValue:
                if (query.Value is null)
                {
                    query.ErrorMessage = "Get by Value attempted. Value must not be null";
                    return false;
                }
                return true;
            case SampleObjectQuery.Query_Type.ByValue_GT:
                if (query.GT_Value is null)
                {
                    query.ErrorMessage = "Get greater than attempted. Greater than value must not be null";
                    return false;
                }
                return true;
            case SampleObjectQuery.Query_Type.ByValue_LT:
                if (query.LT_Value is null)
                {
                    query.ErrorMessage = "Get less than attempted. Less than value must not be null";
                    return false;
                }
                return true;
            case SampleObjectQuery.Query_Type.ByRange:
                if (query.GT_Value is null || query.LT_Value is null)
                {
                    query.ErrorMessage = "Get in range attempted. Greater than and less than values must not be null";
                    return false;
                }
                return true;
        }

        return false;
    }
}
