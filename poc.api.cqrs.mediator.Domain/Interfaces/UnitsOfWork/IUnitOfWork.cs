namespace poc.api.cqrs.mediator.Domain.Interfaces.UnitsOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
