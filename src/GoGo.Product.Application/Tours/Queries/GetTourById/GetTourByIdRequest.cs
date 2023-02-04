using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace GoGo.Product.Application.Tours.Queries.GetTourById
{
    public class GetTourByIdRequest : IRequest<GetTourByIdResponse>
    {
        public int Id { get; set; }
    }
}