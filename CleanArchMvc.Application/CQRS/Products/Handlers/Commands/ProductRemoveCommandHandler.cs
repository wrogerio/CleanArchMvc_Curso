using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.CQRS.Products.Handlers.Commands
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProdutoRepository _repository;

        public ProductRemoveCommandHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null) throw new ApplicationException("Entity could not be found.");

            var result = await _repository.RemoveAsync(product);
            return result;
        }
    }
}