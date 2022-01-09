using AutoMapper;
using Auth.Application.Exceptions;
using Auth.Application.Models;
using Auth.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Roles
{
    public class CreateRole
    {
        public class Command : IRequest<RoleDto>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public List<int> Permissions { get; set; }
        }

        public class Handler : IRequestHandler<Command, RoleDto>
        {
            private readonly RoleManager<Role> _roleManager;
            private readonly IMapper _mapper;

            public Handler(RoleManager<Role> roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<RoleDto> Handle(Command request, CancellationToken cancellationToken)
            {
                // Prevent duplicate roles. Check if role already exists.
                var roleExists = await _roleManager.RoleExistsAsync(request.Name);
                if (roleExists)
                {
                    throw new RestException(HttpStatusCode.BadRequest, "Role already exists");
                }

                // Map role dto to role entity.
                var newRole = _mapper.Map<Role>(request);

                // Create new role.
                var role = await _roleManager.CreateAsync(newRole);
                    
                return _mapper.Map<RoleDto>(role);
            }
        }
    }
}
