using MediatR;
using Searchify.Application.Commands;
using Searchify.Domain.Interfaces;
using Searchify.Domain.Model;

namespace Searchify.Application.CommandHandlers
{
    public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdCommand, Product>
    {
        private readonly IProductService _productService;

        public GetProductByIdCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Product> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductById(request.ProductId);
        }
    }
}
