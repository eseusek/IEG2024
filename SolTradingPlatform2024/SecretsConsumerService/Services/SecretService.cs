namespace SecretsConsumerService.Services
{
    public class SecretService : ISecretService
    {
        private readonly HttpClient _httpClient;

        public SecretService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetSecretAsync(string key)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7172/secrets/{key}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
