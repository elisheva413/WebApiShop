using Entities;

namespace Repositories
{
    public interface IUserPasswordRepository
    {
        int CheckPassword(UserPassword password);
    }
}