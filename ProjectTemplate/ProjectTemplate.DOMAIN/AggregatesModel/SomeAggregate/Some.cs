using ProjectTemplate.DOMAIN.Dtos;
using ProjectTemplate.DOMAIN.Events.SomeEvents;
using ProjectTemplate.DOMAIN.SeedWork;

namespace ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate
{
    public class Some : Entity, IAggregateRoot
    {
        private Some() { } // for ef core

        public long Id { get; set; }

        public string SomeValue { get; set; }

        public SomeEnum SomeEnum { get; set; }
      
        public Some(string someValue, SomeEnum someEnum)
        {
            SomeValue = someValue;
            SomeEnum = someEnum;

            AddDomainEvent(new SomeCreationPostSaveEvent(this));
        }
    }
}
