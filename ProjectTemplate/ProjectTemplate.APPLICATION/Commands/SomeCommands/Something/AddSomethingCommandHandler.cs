using MediatR;
using ProjectTemplate.APPLICATION.Dtos.Commands.SomeCommands.Something;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.CommandRepositories;
using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemplate.APPLICATION.Commands.SomeCommands.Something
{
    public class AddSomethingCommandHandler : IRequestHandler<AddSomethingCommand, long>
    {
        private ICommandRepository<Some> _repository { get; set; }
        public AddSomethingCommandHandler(ICommandRepository<Some> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<long> Handle(AddSomethingCommand request, CancellationToken cancellationToken)
        {
            var some = new Some(request.SomeValue, request.SomeEnum);
            _repository.Add(some);
            await _repository.UnitOfWork.SaveChangesAsync();
            return some.Id;
        }
    }
}
