using MS.Services.Core.Base.Dtos;

namespace MS.Services.Core.Base.Wrapper;

public class ListResponse<T> : IResponse
{
    public ICollection<T> Data { get; protected set; }

    public ListResponse(ICollection<T> data) => Data = data;
}