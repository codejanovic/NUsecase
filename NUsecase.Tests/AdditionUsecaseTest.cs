using NUsecase.Tests.usecaseExecutors;
using NUsecase.Tests.usecaseExtensions;
using NUsecase.Tests.usecases;
using Xunit;

namespace NUsecase.Tests
{
    public class AdditionUsecaseTest: AbstractUsecaseTest<AdditionUsecase.Request, AdditionUsecase.Response>
    {
        protected override bool IsEqual(AdditionUsecase.Response left, AdditionUsecase.Response right)
        {
            return left.Result.Equals(right.Result);
        }

        [Fact]
        public void TestAddition()
        {
            GivenUsecase(r => new AdditionUsecase().Execute(r));
            GivenRequest(new AdditionUsecase.Request(1,2));
            WhenRequestIsExecuted();
            ThenResponseIsNotNull();
            ThenResponseIs(new AdditionUsecase.Response(3));
        }

        [Fact]
        public void TestAdditionWithCalculator()
        {
            GivenUsecase(r => new CalculatorUsecaseExecutor().Execute<AdditionUsecase.Request, AdditionUsecase.Response>(r));
            GivenRequest(new AdditionUsecase.Request(1,2));
            WhenRequestIsExecuted();
            ThenResponseIsNotNull();
            ThenResponseIs(new AdditionUsecase.Response(3));
        }

        [Fact]
        public void TestAdditionWithCalculatorExtension()
        {
            GivenUsecase(r => new CalculatorUsecaseExecutor().Add(r.A, r.B));
            GivenRequest(new AdditionUsecase.Request(1,2));
            WhenRequestIsExecuted();
            ThenResponseIsNotNull();
            ThenResponseIs(new AdditionUsecase.Response(3));
        }
    }
}