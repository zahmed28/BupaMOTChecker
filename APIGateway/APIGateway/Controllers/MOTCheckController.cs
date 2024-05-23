using APIGateway.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MOTCheckController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<MOTCheckController> _logger;

        public MOTCheckController(ILogger<MOTCheckController> logger, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), "mediator cannot be null.");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromBody] GetMOTQuery query)
        {
            try
            {
                _logger.LogInformation("Received request to search.");
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while calling search api.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
