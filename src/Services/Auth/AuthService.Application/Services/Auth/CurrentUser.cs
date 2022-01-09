using Auth.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Auth
{
    public class CurrentUser
    {
        public class Query: IRequest<LoggedInUserDto> 
        {
        }

        public class Handler : IRequestHandler<Query, LoggedInUserDto>
        {
            public Task<LoggedInUserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
