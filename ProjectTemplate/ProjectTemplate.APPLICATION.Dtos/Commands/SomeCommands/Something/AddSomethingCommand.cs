using MediatR;
using ProjectTemplate.DOMAIN.Dtos;

namespace ProjectTemplate.APPLICATION.Dtos.Commands.SomeCommands.Something
{
    public class AddSomethingCommand : IRequest<long>
    {
        public string SomeValue { get; set; }

        public SomeEnum SomeEnum { get; set; }
    }
}
