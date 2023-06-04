using RPCSharp.Shared.Entities;

namespace RPCSharp.Server.Data.Repos;

internal class SampleObjectRepo
{
    internal List<SampleObject> Values { get;}

    internal SampleObjectRepo()
    {
        Values = new()
        {
            new SampleObject
            {
                Id = 1,
                Name = "Object 1",
                Value = 11
            },
            new SampleObject
            {
                Id = 2,
                Name = "Object 2",
                Value = 7
            },
            new SampleObject
            { 
                Id = 3,
                Name = "Object 3",
                Value = 59
            },
            new SampleObject
            { 
                Id = 4,
                Name = "Object 4",
                Value = 37
            }
        };
    }
}
