using FluentNHibernate.Mapping;
using SportFinderApi.Models;

namespace Repository.Mapping
{
    public class SubscriptionMap : ClassMap<Subscription>
    {
        public SubscriptionMap()
        {
            Id(x => x.Id);

            References(x => x.City).Column("CityId").Not.LazyLoad();
            References(x => x.Sport).Column("SportId").Not.LazyLoad();
            Table("Subscriptions");
        }
    }
}
