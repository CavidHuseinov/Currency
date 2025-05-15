
using Currency.Business.Services.Interfaces;
using Currency.Core.Settings;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Currency.Business.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly CurrencySettings _settings;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memory;
        private readonly string cacheKey = "CurrencyCache";
        public CurrencyService(IOptions<CurrencySettings> settings, HttpClient httpClient, IHttpClientFactory httpClientFactory, IMemoryCache memory)
        {
            _settings = settings.Value;
            _httpClient = httpClientFactory.CreateClient();
            _memory = memory;
        }

        public async Task<string> GetCurrency()
        {
            if (_memory.TryGetValue(cacheKey, out var cachedObj) && cachedObj is string cachedCurrency)
            {
                return cachedCurrency;
            }
            var currencyDatas = $"{_settings.BaseUrl}{_settings.LatestEndpoint}{_settings.Prefix}{_settings.ApiKey}";
            var data= await _httpClient.GetAsync(currencyDatas);
            data.EnsureSuccessStatusCode();
            var content = await data.Content.ReadAsStringAsync();
            _memory.Set(cacheKey, content, TimeSpan.FromMinutes(30));
            return content;
        }
    }
}
