using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Searchify.Domain.Model;

namespace SearchDemo.Application.Command
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
