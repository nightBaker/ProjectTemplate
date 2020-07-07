using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;

namespace ProjectTemplate.APPLICATION.Interfaces.Persistence.CommandRepositories
{
    public interface ISomeCommandRepository : ICommandRepository<Some>
    {
    }
}
