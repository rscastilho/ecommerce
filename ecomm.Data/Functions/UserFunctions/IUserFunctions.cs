using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Data.Functions.UserFunctions
{
    public interface IUserFunctions<Usermodel>
    {
        Task<List<Usermodel>> GetAllUsers();
        Task<int> addUser(Usermodel user);
        Task<Usermodel> getUserById(int id);
        Task<Usermodel> getUserByEmail(string email);

        Task<Usermodel> Login(string email,  string password);





    }
}
