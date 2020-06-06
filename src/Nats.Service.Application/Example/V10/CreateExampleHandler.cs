using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Nats.Service.Application.Example.V10
{
    /// <summary>
    /// Класс-обработчик для метода Example POST.
    /// </summary>
    public class CreateExampleHandler : IRequestHandler<CreateExampleCommand, CreateExampleResponse>
    {
        public async Task<CreateExampleResponse> Handle(CreateExampleCommand command, CancellationToken cancellationToken)
        {
            var exampleResponse = new CreateExampleResponse { CreatedResponseId = 42 };
            return await Task.FromResult(exampleResponse);
        }
    }
}