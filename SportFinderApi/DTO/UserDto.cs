﻿using SportFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportFinderApi.DTO
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CityId { get; set; }

        public UserDto(string firstName, string lastName, string userName, string email, string password, int cityId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Password = password;
            CityId = cityId;
        }

        public bool Validate()
        {
            if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Password) || CityId == null) return false;
            return true;

        }
    }
}