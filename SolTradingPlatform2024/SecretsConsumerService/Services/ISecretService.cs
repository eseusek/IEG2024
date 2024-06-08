namespace SecretsConsumerService.Services
{
    public interface ISecretService
    {
        Task<string> GetSecretAsync(string key);
    }
}
