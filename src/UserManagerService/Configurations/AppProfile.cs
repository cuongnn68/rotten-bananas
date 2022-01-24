using AutoMapper;
using UserManagerService.Dtos;
using UserManagerService.Models;
using UserManagerService.Util;

namespace UserManagerService.Configurations;

public class AppProfile : Profile {
    public AppProfile() {
        CreateMap<NewUserRQ, User>().BeforeMap((newUser, user) => newUser.Salt = PasswordUtil.CreateSalt())
                                    .ForMember(
                                        user => user.HashedPassword,
                                        option => option.MapFrom(newUser => PasswordUtil.Hash(newUser.Password, newUser.Salt))
                                    );
        CreateMap<User, UserRP>();
    }
}