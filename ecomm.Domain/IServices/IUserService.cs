using ecomm.Domain.Dtos.User;
using ecomm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Domain.IServices
{
    public interface IUserService
    {
        Task<ResponseModel<List<UserModel>>> GetAllUsers();
        Task<ResponseModel<UserAddDto>> addUser(UserAddDto user);
        Task<ResponseModel<UserModel>> Login(UserModel user);



    }
}
