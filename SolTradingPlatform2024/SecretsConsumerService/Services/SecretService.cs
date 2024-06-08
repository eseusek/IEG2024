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
            var response = await _httpClient.GetAsync($"http://localhost:5265/api/Secrets/{key}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
