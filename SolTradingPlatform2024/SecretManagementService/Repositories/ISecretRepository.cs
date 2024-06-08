namespace SecretManagementService.Repositories
{
    public interface ISecretRepository
    {
        string GetSecret(string key);
        void SetSecret(string key, string value);
    }

}
