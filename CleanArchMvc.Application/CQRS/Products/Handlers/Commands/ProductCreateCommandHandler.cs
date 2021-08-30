using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.CQRS.Products.Handlers.Commands
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProdutoRepository _repository;

        public ProductCreateCommandHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);
            product.CategoryId = request.CategoryId;
            return await _repository.CreateAsync(product);
        }
    }
}