using AutoMapper;
using Auth.Application.Contracts.Repositories;
using Auth.Application.Exceptions;
using Auth.Application.Models;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Categories
{
    public class GetCategory
    {
        public class Query : IRequest<ProductDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public Handler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve product if it exists.
                var existingProduct = await _productRepository.GetByIdAsync(request.Id);
                if (existingProduct  == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Product does not exist.");
                }

                return _mapper.Map<ProductDto>(existingProduct);
            }
        }
    }
}
