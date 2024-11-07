﻿using CQRS.Mediator.Model;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Query;
using MediatR;

namespace CQRS.MediatR.API.Data.Handlers
{
    public class GetEmployeeByIdHandlers : IRequestHandler<GetEmployeeByIdQuery, GetOperationResponse>, 
        IRequestHandler<GetEmployeebyNameQuery, GetOperationResponse>
    {
        private readonly ICrudSL _crudSL;
        public GetEmployeeByIdHandlers(ICrudSL crudSL)
        {
            _crudSL = crudSL;
        }
        public async Task<GetOperationResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _crudSL.GetOperationById(request.Id);
        }

        public async Task<GetOperationResponse> Handle(GetEmployeebyNameQuery request, CancellationToken cancellationToken)
        {
            return await _crudSL.GetOperationByName(request.Name);
        }
    }
}
