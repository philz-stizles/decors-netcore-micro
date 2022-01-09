using AutoMapper;
using Cart.Application.Models;
using Cart.Application.Services.Auth;
using Cart.Domain.Entities;
using System.Collections.Generic;

namespace Cart.Application.Mappers
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterVendor.Command, User>();
            CreateMap<RegisterCustomer.Command, User>()
                .ForMember(
                    u => u.Addresses, 
                    opt => opt.MapFrom(rc => rc.Address == null 
                        ? new List<Address> { } 
                        : new List<Address> { 
                            new Address {
                                Street = rc.Address.Street,
                                City = rc.Address.City,
                                State = rc.Address.State,
                                Country = rc.Address.Country,
                                ZipCode = rc.Address.ZipCode
                            } 
                        }
                    )
                );
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<VendorUsers, UserDto>()
                .ForMember(ud => ud.Email, opt => opt.MapFrom(vu => vu.User.Email))
                .ForMember(ud => ud.Avatar, opt => opt.MapFrom(vu => vu.User.Avatar))
                .ForMember(ud => ud.FullName, opt => opt.MapFrom(vu => $"{vu.User.FirstName} {vu.User.LastName}"));
        }
    }
}
