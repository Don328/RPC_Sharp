using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RPCSharp.Shared.Entities;
using RPCSharp.Shared.Queries;
using RPCSharp.Shared.QueryBuilders;
using System.Net.Http.Json;

namespace RPCSharp.Client.Pages;

public partial class RPC_SampleObj : ComponentBase
{
    private IEnumerable<SampleObject> _objects =
        Enumerable.Empty<SampleObject>();
    private SampleObjectQuery _queryModel = new(0);
    private bool _retainValues = false;

    protected override async Task OnInitializedAsync()
    {
        await OnSelectAll();
    }

    private async Task OnSelectAll()
    {
        var query = new SampleObjectQueryBuilder(
            SampleObjectQuery.Query_Type.GetAll)
                .GetAll()
                .Build(out bool success);

        if (success)
        {
            await PostQuery(query);
        }
    }

    private async Task OnSelectId()
    {
        var query = new SampleObjectQueryBuilder(
            SampleObjectQuery.Query_Type.ById)
                .ById(_queryModel.Id)
                .Build(out bool success);

        if (success)
        {
            await PostQuery(query);
        }
    }

    private async Task OnSelectName()
    {
        var query = new SampleObjectQueryBuilder(
            SampleObjectQuery.Query_Type.ByName)
                .ByName(_queryModel.Name)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
        }
    }

    private async Task OnSelectByValue()
    {
        var query = new SampleObjectQueryBuilder(
            SampleObjectQuery.Query_Type.ByValue)
                .ByValue(_queryModel.Value ?? 0)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
        }
    }

    private async Task OnSelectGreaterThan()
    {
        var query = new SampleObjectQueryBuilder(
            SampleObjectQuery.Query_Type.ByValue_GT)
                .ByValue_GT(
                    _queryModel.GT_Value ?? int.MinValue)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
        }
    }

    private async Task OnSelectLessThan()
    {
        var query = new SampleObjectQueryBuilder(
            SampleObjectQuery.Query_Type.ByValue_LT)
                .ByValue_LT(
                    _queryModel.LT_Value ?? int.MaxValue)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
        }
    }

    private async Task OnSelectRange()
    {
        var query = new SampleObjectQueryBuilder(
            SampleObjectQuery.Query_Type.ByRange)
                .ByRange(
                    greaterThan: _queryModel.GT_Value ?? int.MinValue,
                    lessThan: _queryModel.LT_Value ?? int.MaxValue)
                .Build(out bool success);

        if (success)
        {
            await (PostQuery(query));
        }
    }

    private async Task PostQuery(SampleObjectQuery query)
    {
        var response = await Http.PostAsJsonAsync("SampleObject", query);
        if (response.IsSuccessStatusCode)
        {
            _objects = Enumerable.Empty<SampleObject>();
            var result = await response.Content.ReadFromJsonAsync(typeof(List<SampleObject>));
            if (result is not null)
            {
                _objects = (List<SampleObject>)result;
            }

            RefreshQueryModel();
        }
    }

    private void RefreshQueryModel()
    {
            var newQuery = new SampleObjectQuery(0);
            if (_retainValues)
            {
                RetainQueryValues(newQuery);
            }

            _queryModel = newQuery;
    }

    private void ToggleRetainValues()
    {
        _retainValues = !_retainValues;
    }

    private void RetainQueryValues(
        SampleObjectQuery query)
    {
        query.Id = _queryModel.Id;
        query.Name = _queryModel.Name;
        query.Value = _queryModel.Value;
        query.GT_Value = _queryModel.GT_Value;
        query.LT_Value = _queryModel.LT_Value;
    }
}
