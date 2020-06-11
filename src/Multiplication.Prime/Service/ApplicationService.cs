using System;
using Microsoft.Extensions.Logging;
using static Multiplication.Prime.Model.ApplicationModel;

namespace Multiplication.Prime.Service
{
    public partial class ApplicationService : IApplicationService
    {
        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger<ApplicationService> _logger;

        /// <summary>
        /// Number Service
        /// </summary>
        private readonly INumberService _numberService;

        /// <summary>
        /// Operator Service
        /// </summary>
        private readonly IOperatorService _operatorService;

        /// <summary>
        /// Print Service
        /// </summary>
        private readonly IPrintService _printService;

        /// <summary>
        /// Initialize a new reference of Application Service Class
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="numberService"></param>
        /// <param name="operatorService"></param>
        /// <param name="printService"></param>
        public ApplicationService(ILogger<ApplicationService> logger,
                                  INumberService numberService,
                                  IOperatorService operatorService,
                                  IPrintService printService)
        {
            _logger = logger;
            _numberService = numberService;
            _operatorService = operatorService;
            _printService = printService;
        }

        /// <summary>
        /// Facade class - Process and orchestrate other service implementation
        /// </summary>
        /// <param name="input">Long Int</param>
        /// <returns>Service Codes - Success, Invalid Input, Error</returns>
        public ServiceCode Process(long input)
        {
            try
            {
                _logger.LogInformation("Processing input..");
                _logger.LogDebug($"Processing value - {input}");

                var numbers = _numberService.GetValues(input);

                if (numbers.Count > 0)
                {
                    var gridOutput = _operatorService.Execute(numbers);

                    if(!string.IsNullOrEmpty(gridOutput))
                    {
                        _printService.Print(gridOutput);
                        _logger.LogInformation("Processing Complete");
                        return ServiceCode.SUCCESS;
                    }

                    _logger.LogInformation("Error while generating table, Empty response.");
                    return ServiceCode.APPLICATION_ERROR;

                }

                _logger.LogInformation("Invalid Input. Nothing to process..");
                return ServiceCode.INVALID_INPUT;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing.. Check exception details");
                return ServiceCode.SYSTEM_ERROR;
            }
        }
    }
}