using MediatR;
using ProjectTemplate.DOMAIN.Events.SomeEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemplate.APPLICATION.DomainEvents.Some
{
    public class SomeCreationEventHandler : INotificationHandler<SomeCreationPostSaveEvent>
    {
        public async Task Handle(SomeCreationPostSaveEvent notification, CancellationToken cancellationToken)
        {
            // do something
        }
    }
}
