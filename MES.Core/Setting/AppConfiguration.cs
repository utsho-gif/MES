namespace MES.Core.Setting
{
    public class AppConfiguration
    {
        public int EnablePlmIntegration { get; set; } = 0;
        public int EnableHrisIntegration { get; set; } = 0;
        public int EnableWmsIntegration { get; set; } = 0;
        public int EnableStrictShiftValidation { get; set; } = 0;
        public int EnableQualityGateCheck { get; set; } = 1;
    }
}
