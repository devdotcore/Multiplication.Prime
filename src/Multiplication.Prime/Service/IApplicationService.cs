

using static Multiplication.Prime.Model.ApplicationModel;

namespace Multiplication.Prime.Service
{
    public interface IApplicationService
    {
        /// <summary>
        /// Facade class - Process and orchestrate other service implementation
        /// </summary>
        /// <param name="input">Long Int</param>
        /// <returns>Service Codes - Success, Invalid Input, Error</returns>
        ServiceCode Process(long input);
    }
}