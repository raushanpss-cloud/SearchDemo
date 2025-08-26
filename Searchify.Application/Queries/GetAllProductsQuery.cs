using MediatR;
using Searchify.Domain.Model;

namespace Searchify.Application.Commands
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }
}
