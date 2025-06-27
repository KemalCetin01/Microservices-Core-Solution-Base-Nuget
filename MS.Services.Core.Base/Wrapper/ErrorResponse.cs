using MS.Services.Core.Base.Dtos;

namespace MS.Services.Core.Base.Wrapper;

public sealed class ErrorResponse : IResponse
{
    public string? Code { get; set; }
    public string? Message { get; set; }
    public IDictionary<string, string[]>? Errors { get; set; }
}