
namespace Currency.Core.Settings
{
    public class CurrencySettings
    {
        public string ApiKey { get; set; } = default!;
        public string BaseUrl { get; set; } = default!;
        public string LatestEndpoint { get; set; } = default!;
        public string Prefix {  get; set; } = default!;
    }
}
