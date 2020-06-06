using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Nats.Service.Application.Example.V10
{
    [ExcludeFromCodeCoverage]
    public class CreateExampleCommand : IRequest<CreateExampleResponse>
    {
        public int Id { get; set; }
    }
}