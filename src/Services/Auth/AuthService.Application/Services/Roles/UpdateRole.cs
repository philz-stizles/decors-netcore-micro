using AutoMapper;
using Auth.Application.Exceptions;
using Auth.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Services.Roles
{
    public class UpdateRole
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<int> Permissions { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly RoleManager<Role> _roleManager;
            private readonly IMapper _mapper;

            public Handler(RoleManager<Role> roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, 
                CancellationToken cancellationToken)
            {
                // Prevent duplicate roles. Check if role already exists.
                var roleExists = await _roleManager.RoleExistsAsync(request.Name);
                if (!roleExists)
                {
                    throw new RestException(HttpStatusCode.BadRequest, "Role does not exist");
                }

                // Map role dto to role entity.
                var updatedRole = _mapper.Map<Role>(request);

                // Create new product.
                await _roleManager.UpdateAsync(updatedRole);

                return Unit.Value;
            }
        }
    }
}
