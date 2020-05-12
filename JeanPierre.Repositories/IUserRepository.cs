using JeanPierre.Models;

namespace JeanPierre.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
