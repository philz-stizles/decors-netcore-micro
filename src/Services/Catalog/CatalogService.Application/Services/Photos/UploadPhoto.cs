using AutoMapper;
using Auth.Application.Contracts.Services;
using Auth.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Photos
{
    public class UploadPhoto
    {
        public class Command : IRequest<PhotoUploadResponseDto>
        {
            public IFormFile Photo { get; set; }
        }

        public class Handler : IRequestHandler<Command, PhotoUploadResponseDto>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            // private readonly IPhotoAccessor _photoAccessor;

            public Handler(IUserAccessor userAccessor, IMapper mapper) 
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
            }


            public async Task<PhotoUploadResponseDto> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
