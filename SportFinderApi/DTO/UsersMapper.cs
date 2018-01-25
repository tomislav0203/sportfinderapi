using SportFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportFinderApi.DTO
{
    public static class UsersMapper
    {
        public static UserDto MapUserToUserDto(User user)
        {
            return new UserDto(user.FirstName, user.LastName, user.UserName, user.Email, user.Password, user.City.Id, user.City.Name);
        }

        public static User MapUserDtoToUser(UserDto user)
        {
            return new User() {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email
            };
        }
    }
}