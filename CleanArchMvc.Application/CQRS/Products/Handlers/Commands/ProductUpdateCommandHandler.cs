using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.CQRS.Products.Handlers.Commands
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProdutoRepository _repository;

        public ProductUpdateCommandHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null) throw new ApplicationException("Entity could not be found.");

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image,
                request.CategoryId);

            return await _repository.UpdateAsync(product);
        }
    }
}