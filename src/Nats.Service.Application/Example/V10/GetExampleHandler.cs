using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Nats.Service.Application.Example.V10
{
    /// <summary>
    /// Класс-обработчик для метода Example GET.
    /// </summary>
    public class GetExampleHandler : IRequestHandler<GetExampleQuery, GetExampleResponse>
    {
        public async Task<GetExampleResponse> Handle(GetExampleQuery command, CancellationToken cancellationToken)
        {
            var exampleResponse = new GetExampleResponse { GetResponseId = 42 };
            return await Task.FromResult(exampleResponse);
        }
    }
}