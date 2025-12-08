using Entities;
using Repositeries;

namespace Service

{
    public interface IUserPasswordService
    {
        int CheckPassword(string password);
    }
}