namespace MS.Services.Core.Base.Dtos.Response;

public interface IAuditableResponseDto
{
    DateTime CreatedDate { get; set; }
    Guid? CreatedBy { get; set; }
    DateTime? UpdatedDate { get; set; }
    Guid? UpdatedBy { get; set; }
}