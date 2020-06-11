using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Multiplication.Prime.Service;
using static Multiplication.Prime.Model.ApplicationModel;

namespace Multiplication.Prime.Controllers
{
    [ApiController]
    [Route("prime/")]
    public class ApplicationController : ControllerBase
    {
        /// <summary>
        /// Applcation Service
        /// </summary>
        private readonly IApplicationService _applicationService;

        /// <summary>
        /// Logger
        /// </summary>
        private ILogger<ApplicationController> _logger;

        /// <summary>
        /// Application Controller Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="applicationService"></param>
        public ApplicationController(ILogger<ApplicationController> logger, IApplicationService applicationService)
        {
            _logger = logger;
            _applicationService = applicationService;
        }

        /// <summary>
        /// Generate multiplication table for prime number present in input N.
        /// Display the output in in grid form.
        /// No File generated for invalid input or service error.
        /// </summary>
        /// <param name="input">Input Number (N)</param>
        /// <returns>API Code, 201 - Success</returns>
        [HttpGet]
        [Route("{input}/multiplication")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> GetAction([FromRoute] long input)
        {
            if (input > 0)
            {
                var output = _applicationService.Process(input);

                if (output == ServiceCode.SUCCESS)
                    return StatusCode(StatusCodes.Status201Created, "Success, File Generated");
                else if (output == ServiceCode.INVALID_INPUT)
                    return StatusCode(StatusCodes.Status400BadRequest, "Invalid Input");
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

            _logger.LogError("Invalid Input");
            return StatusCode(StatusCodes.Status400BadRequest, "Invalid Input");

        }



    }
}