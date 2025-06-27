using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MS.Services.Core.Base.Extentions;

public static class HostingEnvironmentExtensions
{
    public const string UatEnvironment = "Uat";

    public static bool IsUat(this IWebHostEnvironment hostingEnvironment) =>
        hostingEnvironment.IsEnvironment(UatEnvironment);
}