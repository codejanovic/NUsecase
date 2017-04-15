using NUnit.Framework;
using NUsecase.Tests.usecaseExecutors;
using NUsecase.Tests.usecases;

namespace NUsecase.Tests
{
    public class AdditionUsecaseTest: AbstractUsecaseTest<AdditionUsecase.Request, AdditionUsecase.Response>
    {
        protected override bool IsEqual(AdditionUsecase.Response left, AdditionUsecase.Response right)
        {
            return left.Result.Equals(right.Result);
        }

        [Test]
        public void TestAddition()
        {
            GivenUsecase(r => new AdditionUsecase().Execute(r));
            GivenRequest(new AdditionUsecase.Request(1,2));
            WhenRequestIsExecuted();
            ThenResponseIsNotNull();
            ThenResponseIs(new AdditionUsecase.Response(3));
        }

        [Test]
        public void TestAdditionWithCalculator()
        {
            GivenUsecase(r => new CalculatorUsecaseExecutor().Execute<AdditionUsecase.Request, AdditionUsecase.Response>(r));
            GivenRequest(new AdditionUsecase.Request(1,2));
            WhenRequestIsExecuted();
            ThenResponseIsNotNull();
            ThenResponseIs(new AdditionUsecase.Response(3));
        }
    }
}