using AutoMapper;
using Auth.Application.Contracts.Repositories;
using Auth.Application.Contracts.Services;
using Auth.Application.Exceptions;
using Auth.Application.Models;
using Auth.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Auth
{
    public class RegisterVendorWithEmailVerification
    {
        public class Command : IRequest<LoggedInUserDto>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, LoggedInUserDto>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;
            private readonly IVendorRepository _vendorRepository;
            private readonly IMapper _mapper;
            private readonly IJwtService _jwtService;

            public Handler(UserManager<User> userManager, RoleManager<Role> roleManager, IVendorRepository vendorRepository,
                IMapper mapper, IJwtService jwtService)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _vendorRepository = vendorRepository;
                _mapper = mapper;
                _jwtService = jwtService;
            }

            public async Task<LoggedInUserDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var newUser = _mapper.Map<User>(request);
                if(string.IsNullOrEmpty(newUser.UserName))
                {
                    newUser.UserName = request.Email;
                }

                // Manually confirm email.
                newUser.EmailConfirmed = true;

                // Create new user.
                var result = await _userManager.CreateAsync(newUser, request.Password);
                if (!result.Succeeded) throw new RestException(HttpStatusCode.BadRequest, new
                {
                    errors = string.Join(", ", result.Errors.Select(e => e.Description))
                });

                // Create vendor account.
                var createdUser = await _userManager.FindByIdAsync(newUser.Id.ToString());
                var newVendor = await _vendorRepository.AddAsync(new Vendor {
                    Users = new List<VendorUsers>
                    {
                        new VendorUsers
                        {
                            User = createdUser
                        }
                    }
                });

                return new LoggedInUserDto
                {
                    UserDetails = _mapper.Map<UserDto>(newUser),
                    Token = _jwtService.CreateToken(newUser, new List<string> {})
                };
            }
        }
    }
}
