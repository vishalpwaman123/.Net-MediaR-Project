using CQRS.Mediator.Model;
using MediatR;

namespace CQRS.MediatR.API.Data.Query
{
    public class GetEmployeebyNameQuery : IRequest<GetOperationResponse>
    {
        public string? Name { get; set; }
    }
}
