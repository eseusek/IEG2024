using Microsoft.AspNetCore.Mvc;
using SecretsConsumerService.Services;

namespace SecretsConsumerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ISecretService _secretService;

        public ValuesController(ISecretService secretService)
        {
            _secretService = secretService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var secret = await _secretService.GetSecretAsync("my-secret-key");
            return Ok(new { secret });
        }
    }
}