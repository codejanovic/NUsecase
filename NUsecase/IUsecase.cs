using System;

namespace NUsecase
{
    public interface IUsecase<in TRequest, out TResponse> {
        TResponse Execute(TRequest request);
    }
}