using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace GoGo.Product.Application.Tours.Queries.GetTourById
{
    public class GetTourByIdHandler : IRequestHandler<GetTourByIdRequest, GetTourByIdResponse>
    {
        public Task<GetTourByIdResponse> Handle(GetTourByIdRequest request, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}