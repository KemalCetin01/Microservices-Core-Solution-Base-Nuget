namespace MS.Services.Core.Base.Enums;

public enum AuditType
{
    [Display(Name = "Eklendi")] Insert = 1,

    [Display(Name = "Güncellendi")] Update = 2,

    [Display(Name = "Silindi")] Delete = 3
}