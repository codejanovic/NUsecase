using System;
using Xunit;

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

        protected AbstractUsecaseTest()
        {
            _usecase = null;
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
            Assert.NotNull(_request);
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
            Assert.True(IsEqual(_response, expected));
        }

        protected void ThenResponseIsNotNull()
        {
            Assert.NotNull(_response);
        }

        protected void ThenErrorIsOfType<TError>()
        {
            Assert.IsType<TError>(_error);
        }

        protected void ThenErrorMessageIs(String expected)
        {
            Assert.NotNull(_error);
            Assert.Equal(expected, _error.Message);
        }
    }
}