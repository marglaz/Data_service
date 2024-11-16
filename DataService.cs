using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Dadata_service.Models;
using System.Net.Http.Json;
using System.Collections.Generic;
using AutoMapper;

namespace Dadata_service
{
    public interface IDadataService
    {
        Task<AddressResponse> CleanAddressAsync(string rawAddress);
    }

    public class DadataService : IDadataService 
    {
        private readonly HttpClient _httpClient;
        private readonly DadataOptions _options;

        public DadataService(IHttpClientFactory httpClientFactory, IOptions<DadataOptions> options)
        {
            _httpClient = httpClientFactory.CreateClient();
            _options = options.Value;
        }

        public async Task<AddressResponse> CleanAddressAsync(string rawAddress)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {_options.ApiKey}");
            _httpClient.DefaultRequestHeaders.Add("X-Secret", $"{_options.Secret}");

            var requestBody = rawAddress;
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_options.ApiUrl, content);

            response.EnsureSuccessStatusCode();

            var resultContent = await response.Content.ReadAsStringAsync();

            List<AddressRequest> listrequest = JsonConvert.DeserializeObject<List<AddressRequest>>(resultContent);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();

            return mapper.Map<AddressResponse>(listrequest);
        }
    }
}
