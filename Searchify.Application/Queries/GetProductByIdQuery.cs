using MediatR;
using Searchify.Domain.Model;

namespace Searchify.Application.Commands
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int ProductId { get; set; }

        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
