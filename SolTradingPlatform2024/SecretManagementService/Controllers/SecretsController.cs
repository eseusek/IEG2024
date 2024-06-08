using Microsoft.AspNetCore.Mvc;
using SecretManagementService.Repositories;

namespace SecretManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class SecretsController : ControllerBase
    {
        private readonly ISecretRepository _secretRepository;

        public SecretsController(ISecretRepository secretRepository)
        {
            _secretRepository = secretRepository;
        }

        [HttpGet("{key}")]
        public IActionResult GetSecret(string key)
        {
            var secret = _secretRepository.GetSecret(key);
            if (secret == null)
            {
                return NotFound();
            }
            return Ok(secret);
        }

        [HttpPost]
        public IActionResult SetSecret([FromBody] SecretModel secret)
        {
            _secretRepository.SetSecret(secret.Key, secret.Value);
            return Ok();
        }
    }

    public class SecretModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
