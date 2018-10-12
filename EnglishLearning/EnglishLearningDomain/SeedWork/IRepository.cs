namespace EnglishLearningDomain.SeedWork
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
