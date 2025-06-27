namespace MS.Services.Core.Base.Constants;

public static class Constants
{
    public const string DefaultLocalizationResourcePath = "Resources";
    public const string DefaultLocale = "tr-TR";

    public static class Microservice
    {
        public const string Product = "product";
        public const string Identity = "identity";
        public const string Common = "common";
        public const string Notification = "notificaton";
        public const string Erp = "erp";
    }

    public static class Cache
    {
        public const string Delimiter = ":";
        public static class BaseKey
        {
            public const string Product = Microservice.Product;
            public const string Identity = Microservice.Identity;
            public const string Common = Microservice.Common;
            public const string Notification = Microservice.Notification;
            public const string Erp = Microservice.Erp;
        }
    }
}