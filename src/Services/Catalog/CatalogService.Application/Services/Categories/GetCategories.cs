using AutoMapper;
using Auth.Application.Contracts.Repositories;
using Auth.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Categories
{
    public class GetCategories
    {
        public class Query : IRequest<List<CategoryDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<CategoryDto>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<List<CategoryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve categorys
                var categorys = await _categoryRepository.GetAllAsync();
                    
                return _mapper.Map<List<CategoryDto>>(categorys);
            }
        }
    }
}
