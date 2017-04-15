using NUsecase.Tests.usecaseExecutors;
using NUsecase.Tests.usecases;

namespace NUsecase.Tests.usecaseExtensions
{
    public static class CalculatorUsecaseExecutorExtensions
    {
        public static AdditionUsecase.Response Add(this CalculatorUsecaseExecutor usecaseExecutor, int a, int b)
        {
            return usecaseExecutor.Execute<AdditionUsecase.Request, AdditionUsecase.Response>(
                new AdditionUsecase.Request(a, b));
        }

        public static SubtractionUsecase.Response Subtract(this CalculatorUsecaseExecutor usecaseExecutor, int a, int b)
        {
            return usecaseExecutor.Execute<SubtractionUsecase.Request, SubtractionUsecase.Response>(
                new SubtractionUsecase.Request(a, b));
        }
    }
}