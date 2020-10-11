using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.DOMAIN.Events.SomeEvents
{
    public class SomeCreationPostSaveEvent : IPostSaveEvent
    {
        public SomeCreationPostSaveEvent(Some some)
        {
            Some = some;
        }

        public Some Some { get; }
    }
}
