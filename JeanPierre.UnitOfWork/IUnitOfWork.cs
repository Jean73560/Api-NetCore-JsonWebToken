using JeanPierre.Repositories;

namespace JeanPierre.UnitOfWork
{
   public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IUserRepository User { get; }
        ISupplierRepository Supplier { get; }
    }
}
