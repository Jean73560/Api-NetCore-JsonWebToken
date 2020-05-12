using JeanPierre.Models;
using System.Collections.Generic;

namespace JeanPierre.Repositories
{
    public interface ISupplierRepository:IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPagedList(int page, int rows);
    }
}
