using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.CQRS.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}