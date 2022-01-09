using AutoMapper;
using Auth.Application.Contracts.Repositories;
using Auth.Application.Exceptions;
using Auth.Domain.Entities;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Categories
{
    public class UpdateCategory
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public Handler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, 
                CancellationToken cancellationToken)
            {
                var existingProduct = await _productRepository.GetByIdAsync(request.Id);
                if (existingProduct == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Product does not exist");
                }

                // Map updated product dto to product entity.
                var updatedProduct = _mapper.Map<Product>(request);

                // Create new product.
                await _productRepository.UpdateAsync(updatedProduct);

                return Unit.Value;
            }
        }
    }
}
