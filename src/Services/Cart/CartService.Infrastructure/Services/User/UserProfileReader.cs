using AutoMapper;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using Decors.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Reactivities.Infrastructure.User
{
    public class UserProfileReader : IUserProfileReader
    {
        private readonly DataDbContext _context;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public UserProfileReader(DataDbContext context, IUserAccessor userAccessor, IMapper mapper)
        {
            _context = context;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> ReadProfile(string username)
        {
            var currentUser = await _context.Users.SingleOrDefaultAsync(u => u.UserName == _userAccessor.GetCurrentUserName());
            if (currentUser == null) throw new RestException(HttpStatusCode.Unauthorized, "Unauthorized access");

            var existingUser = await _context.Users
                    .SingleOrDefaultAsync(u => u.UserName == username);
            if (existingUser == null) throw new RestException(HttpStatusCode.NotFound, "User not found");

            var userProfileDto = _mapper.Map<UserProfileDto>(existingUser);

            return userProfileDto;
        }
    }
}

