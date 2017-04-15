using NUsecase.Tests.usecaseExecutors;
using NUsecase.Tests.usecaseExtensions;
using NUsecase.Tests.usecases;
using Xunit;

namespace NUsecase.Tests
{
    public class SubtractionUsecaseTest: AbstractUsecaseTest<SubtractionUsecase.Request, SubtractionUsecase.Response>
    {
        protected override bool IsEqual(SubtractionUsecase.Response left, SubtractionUsecase.Response right)
        {
            return left.Result.Equals(right.Result);
        }

        [Fact]
        public void TestSubtraction()
        {
            GivenUsecase(r => new SubtractionUsecase().Execute(r));
            GivenRequest(new SubtractionUsecase.Request(1,2));
            WhenRequestIsExecuted();
            ThenResponseIsNotNull();
            ThenResponseIs(new SubtractionUsecase.Response(-1));
        }

        [Fact]
        public void TestSubtractionWithCalculator()
        {
            GivenUsecase(r => new CalculatorUsecaseExecutor().Execute<SubtractionUsecase.Request, SubtractionUsecase.Response>(r));
            GivenRequest(new SubtractionUsecase.Request(1,2));
            WhenRequestIsExecuted();
            ThenResponseIsNotNull();
            ThenResponseIs(new SubtractionUsecase.Response(-1));
        }

        [Fact]
        public void TestSubtractionWithCalculatorExtension()
        {
            GivenUsecase(r => new CalculatorUsecaseExecutor().Subtract(r.A, r.B));
            GivenRequest(new SubtractionUsecase.Request(1,2));
            WhenRequestIsExecuted();
            ThenResponseIsNotNull();
            ThenResponseIs(new SubtractionUsecase.Response(-1));
        }
    }
}