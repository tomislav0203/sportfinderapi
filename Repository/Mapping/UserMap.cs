﻿using FluentNHibernate.Mapping;
using SportFinderApi.Models;

namespace Repository.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.UserName);
            Map(x => x.Email);
            Map(x => x.Password);
            References(x => x.City).Column("CityId").Not.LazyLoad();
            HasManyToMany(x => x.Events).Table("UsersEvents").ParentKeyColumn("UserId").ChildKeyColumn("EventId").Inverse().Not.LazyLoad();
            Table("Users");
        }
    }
}
