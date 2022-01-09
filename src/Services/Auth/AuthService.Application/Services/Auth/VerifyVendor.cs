using AutoMapper;
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
    public class VerifyVendor
    {
        public class Query : IRequest<LoggedInUserDto>
        {
            public string Token { get; set; }
        }


        public class Handler : IRequestHandler<Query, LoggedInUserDto>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;
            private readonly IMapper _mapper;
            private readonly IJwtService _jwtService;

            public Handler(UserManager<User> userManager, RoleManager<Role> roleManager, 
                IMapper mapper, IJwtService jwtService)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _mapper = mapper;
                _jwtService = jwtService;
            }

            public async Task<LoggedInUserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return new LoggedInUserDto
                {
                };
            }
        }
    }
}
