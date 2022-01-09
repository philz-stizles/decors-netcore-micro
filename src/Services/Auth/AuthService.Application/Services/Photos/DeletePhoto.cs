using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Photos
{
    public class DeletePhoto
    {

        public class Command : IRequest<Unit>
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Command, Unit>
        {

            public Handler() 
            { 
            }


            public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
