using AutoMapper;
using Cart.Application.Contracts.Repositories;
using Cart.Application.Models.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cart.Application.Services.Cart
{
    public class GetCart
    {
        public class Query: IRequest<CartDto>
        {
            public string CartId { get; set; }
        }

        public class Handler : IRequestHandler<Query, CartDto>
        {
            private readonly ICartService _cartRepository;
            private readonly IMapper _mapper;

            public Handler(ICartService cartRepository, IMapper mapper)
            {
                _cartRepository = cartRepository;
                _mapper = mapper;
            }

            public async Task<CartDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var cart = await _cartRepository.GetCartAsync(request.CartId);

                return _mapper.Map<CartDto>(cart);
            }
        }
    }
}
