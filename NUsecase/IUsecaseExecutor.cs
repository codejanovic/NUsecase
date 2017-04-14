namespace NUsecase
{
    public interface IUsecaseExecutor
    {
        TResponse Execute<TRequest, TResponse>(TRequest request);
    }
}