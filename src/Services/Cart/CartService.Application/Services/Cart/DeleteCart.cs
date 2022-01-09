using AutoMapper;
using Cart.Application.Contracts.Repositories;
using Cart.Application.Models.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cart.Application.Services.Cart
{
    public class DeleteCart
    {
        public class Command : IRequest
        {
            public string CartId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ICartService _cartRepository;
            private readonly IMapper _mapper;

            public Handler(ICartService cartRepository, IMapper mapper)
            {
                _cartRepository = cartRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _cartRepository.DeleteCartAsync(request.CartId);

                return Unit.Value;
            }
        }
    }
}

