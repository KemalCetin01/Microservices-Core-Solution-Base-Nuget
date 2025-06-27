namespace MS.Services.Core.Base.Dtos.Response;

public abstract class BaseAuditableResponseDto : IAuditableResponseDto
{
    public DateTime CreatedDate { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
}