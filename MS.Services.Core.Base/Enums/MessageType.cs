namespace MS.Services.Core.Base.Enums;

public enum MessageType
{
    [Display(Name = "Hata")] Error,
    [Display(Name = "Bilgi")] Info,
    [Display(Name = "Uyarı")] Warning,
    [Display(Name = "Detay")] Detail
}