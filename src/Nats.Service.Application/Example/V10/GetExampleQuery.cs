using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Nats.Service.Application.Example.V10
{
    [ExcludeFromCodeCoverage]
    public class GetExampleQuery : IRequest<GetExampleResponse>
    {
        public GetExampleQuery(int id) => Id = id;

        public int Id { get; set; }
    }
}