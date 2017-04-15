using NUsecase.Executors;
using NUsecase.Tests.usecases;

namespace NUsecase.Tests.usecaseExecutors
{
    public class CalculatorUsecaseExecutor: ManualUsecaseExecutor
    {
        public CalculatorUsecaseExecutor()
        {
            Register(typeof(AdditionUsecase.Request), new AdditionUsecase());
            Register(typeof(SubtractionUsecase.Request), new SubtractionUsecase());
        }
    }
}