using System;
using NUnit.Framework;

namespace NUsecase.Tests
{

    public abstract class AbstractUsecaseTest<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {

        public delegate TResponse Execute(TRequest request);

        private Execute _usecase;
        private TRequest _request;
        private TResponse _response;
        private Exception _error;

        [SetUp]
        public void Setup()
        {
            _request = null;
            _response = null;
            _error = null;
        }

        protected abstract bool IsEqual(TResponse left, TResponse right);

        protected void GivenUsecase(Execute usecaseDelegate)
        {
            _usecase = usecaseDelegate;
        }

        protected void GivenRequest(TRequest request)
        {
            _request = request;
        }

        protected void WhenRequestIsExecuted()
        {
            Assert.NotNull(_request, "Expected request, but received null. Did you call GivenRequest() in your test?");
            try
            {
                _response = _usecase(_request);
            }
            catch (Exception e)
            {
                _error = e;
            }
        }

        protected void ThenResponseIs(TResponse expected)
        {
            Assert.IsTrue(IsEqual(_response, expected));
        }

        protected void ThenResponseIsNotNull()
        {
            Assert.NotNull(_response);
        }

        protected void ThenErrorIsOfType<TError>()
        {
            Assert.IsInstanceOf<TError>(_error);
        }

        protected void ThenErrorMessageIs(String expected)
        {
            Assert.NotNull(_error, $"Expected error with message '{expected}', but nothing was thrown.");
            Assert.AreEqual(expected, _error.Message);
        }
    }
}