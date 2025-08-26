using MediatR;
using Searchify.Domain.Model;

namespace Searchify.Application.Commands
{
    public class AuthenticateCommand : IRequest<string>
    {
        public User User { get; set; }

        public AuthenticateCommand(User user)
        {
            User = user;
        }
    }
}
