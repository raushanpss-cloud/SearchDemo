using MediatR;
using Searchify.Domain.Model;

namespace Searchify.Application.Commands
{
    public class GetProductByIdCommand : IRequest<Product>
    {
        public int ProductId { get; set; }

        public GetProductByIdCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
