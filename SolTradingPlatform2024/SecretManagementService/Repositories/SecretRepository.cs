namespace SecretManagementService.Repositories
{
    public class SecretRepository : ISecretRepository
    {
        private readonly Dictionary<string, string> _secrets = new();

        public string GetSecret(string key)
        {
            _secrets.TryGetValue(key, out var value);
            return value;
        }

        public void SetSecret(string key, string value)
        {
            _secrets[key] = value;
        }
    }
}
