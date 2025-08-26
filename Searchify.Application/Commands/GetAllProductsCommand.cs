using MediatR;
using Searchify.Domain.Model;

namespace Searchify.Application.Commands
{
    public class GetAllProductsCommand : IRequest<IEnumerable<Product>>
    {

    }
}
