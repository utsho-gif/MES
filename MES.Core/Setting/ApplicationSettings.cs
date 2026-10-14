namespace MES.Core.Setting
{
    public class ApplicationSettings
    {
        public static string BaseUrl { get; set; } = "http://localhost:5000/";
        public static string AppKey { get; set; } = "MES_APP_KEY";
        public static string SecretKey { get; set; } = "bWVzX3NlY3JldF9rZXlfMjAyNg==";
        public static double TokenExpireMinutes { get; set; } = 480;
        public static int KeyExpireMinutes { get; set; } = 60;

        // Integration Endpoints
        public static string PlmApiUrl { get; set; } = "";
        public static string HrisApiUrl { get; set; } = "";
        public static string WmsApiUrl { get; set; } = "";

        // MES Performance Settings
        public static int MaxBatchScanLimit { get; set; } = 1000;
        public static int DefaultPlantId { get; set; } = 1;
    }
}
