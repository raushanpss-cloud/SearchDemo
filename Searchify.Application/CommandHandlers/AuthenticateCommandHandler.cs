using MediatR;
using Searchify.Application.Commands;
using Searchify.Domain.Interfaces;

namespace Searchify.Application.CommandHandlers
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, string>
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateCommandHandler(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public async Task<string> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _authenticateService.AuthenticateUser(request.User);
        }
    }
}
