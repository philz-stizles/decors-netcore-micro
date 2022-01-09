using AutoMapper;
using Auth.Application.Contracts.Services;
using Auth.Application.Exceptions;
using Auth.Application.Models;
using Auth.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Auth
{
    public class Login
    {
        public class Query: IRequest<LoggedInUserDto> 
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class QueryValidator: AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, LoggedInUserDto>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;
            private readonly SignInManager<User> _signInManager;
            private readonly IMapper _mapper;
            private readonly IJwtService _jwtService;

            public Handler(UserManager<User> userManager, RoleManager<Role> roleManager,
                SignInManager<User> signInManager, IMapper mapper, IJwtService jwtService)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _signInManager = signInManager;
                _mapper = mapper;
                _jwtService = jwtService;
            }
            public async Task<LoggedInUserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                // Chack if the User exists.
                var existingUser = await _userManager.FindByEmailAsync(request.Email);
                if (existingUser == null) throw new RestException(HttpStatusCode.Unauthorized, "Invalid email/password");

                // Validate user's password.
                var result = await _signInManager.CheckPasswordSignInAsync(existingUser, request.Password, false);
                if (!result.Succeeded) throw new RestException(HttpStatusCode.Unauthorized, "Invalid email/password"); ;

                // Retrieve user roles.
                var userRoles = await _userManager.GetRolesAsync(existingUser);

                // Generate user token
                var token = _jwtService.CreateToken(existingUser, userRoles);

                // Map user entity to user dto.
                var userDto = _mapper.Map<UserDto>(existingUser);

                // Return user login details
                return new LoggedInUserDto
                {
                    UserDetails = userDto,
                    Token = token,
                    Roles = userRoles
                };
            }
        }
    }
}
