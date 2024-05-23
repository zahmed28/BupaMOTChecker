using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOTCheckInternalService.Application.Queries;

namespace MOTCheckInternalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MOTCheckController : ControllerBase
    {
        private readonly ILogger<MOTCheckController> _logger;
        private readonly IMediator _mediator;
        public MOTCheckController(ILogger<MOTCheckController> logger, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), "mediator cannot be null.");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromBody] GetMOTQuery getMOTQuery)
        {
            try
            {
                _logger.LogInformation("Called GetMOTHandler method");
                var result = await _mediator.Send(getMOTQuery);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while calling GetMOTHandler method.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}

