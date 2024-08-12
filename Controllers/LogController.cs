using Microsoft.AspNetCore.Mvc;

namespace LogRegister.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Information")]
        public IActionResult LogInformation()
        {
            _logger.LogInformation("Confirmação de que as coisas estão funcionando como esperado.");

            return Ok();
        }

        [HttpPost("Debug")]
        public IActionResult LogDebug()
        {
            _logger.LogDebug("Informações detalhadas, tipicamente de interesse apenas ao diagnosticar problemas.");

            return Ok();
        }

        [HttpPost("Warning")]
        public IActionResult LogWarning()
        {
            _logger.LogWarning(" Um indicativo de que algo inesperado aconteceu, ou uma indicação de algum problema no futuro (ex.: “cerca de 80% do disco foi utilizado”).");

            return Ok();
        }

        [HttpPost("Error")]
        public IActionResult LogError()
        {
            _logger.LogError("Devido a um problema mais grave, o software não conseguiu realizar alguma função.");

            return Ok();
        }

        [HttpPost("Critical")]
        public IActionResult LogCritical()
        {
            _logger.LogCritical("Um erro grave, indicando que o programa pode não conseguir continuar em execução.");

            return Ok();
        }
    }
}
