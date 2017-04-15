namespace NUsecase.Tests.usecases
{
    public class SubtractionUsecase: IUsecase<SubtractionUsecase.Request, SubtractionUsecase.Response>
    {
        public class Request
        {
            public readonly int A;
            public readonly int B;

            public Request(int a, int b)
            {
                A = a;
                B = b;
            }
        }

        public class Response
        {
            public readonly int Result;

            public Response(int result)
            {
                Result = result;
            }
        }

        public Response Execute(Request request)
        {
            return new Response(request.A - request.B);
        }
    }
}