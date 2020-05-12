using JeanPierre.Models;
using System.Collections.Generic;
using System.Linq;

namespace JeanPierre.Repositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        IEnumerable<Customer> CustomerPagedList(int page, int rows);
    }
}
