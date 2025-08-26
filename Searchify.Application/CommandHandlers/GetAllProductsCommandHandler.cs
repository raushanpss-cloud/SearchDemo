using MediatR;
using Searchify.Application.Commands;
using Searchify.Domain.Interfaces;
using Searchify.Domain.Model;

namespace Searchify.Application.CommandHandlers
{
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsCommand, IEnumerable<Product>>
    {

        private readonly IProductService _productService;

        public GetAllProductsCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllProducts();
        }
    }
}
