using ecomm.Data.Functions.UserFunctions;
using ecomm.Domain.IServices;
using ecomm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Services.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserFunctions<UserModel> _userFunction;
        

        public UserServices(IUserFunctions<UserModel> userFunction)
        {
            _userFunction = userFunction;
        }

        public async Task<ResponseModel<UserModel>> addUser(UserModel user)
        {
            try
            {
                ResponseModel<UserModel> response = new();

                if(user == null)
                {
                    response.Data = null;
                    response.Message = "Preencha todos os campos obrigatórios";
                    return response;
                }

                var userExist = await _userFunction.getUserByEmail(user.Email);
                if (userExist != null)
                {
                    response.Message = $"{user.Email} email já cadastrado";
                    response.Data = userExist;
                    return response;
                }

                var result = await _userFunction.addUser(user);
                if(result == null)
                {
                    response.Data = null;
                    response.Message = "Erro ao cadastrar usuário";
                    return response;
                }


                var userByEmail = await _userFunction.getUserById(result);
                response.Data = userByEmail;
                response.Message = $"{userByEmail.Name} cadastrado com sucesso!";
                return response;


            } catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> GetAllUsers()
        {
            try
            {
                ResponseModel<List<UserModel>> response = new();
                var result = await _userFunction.GetAllUsers();
                if (result.Count == 0)
                {
                    response.Data = null;
                    response.Message = "Nenhum usuário encontrado";
                    return response;
                }
                response.Data = result;
                response.Message = $"{result.Count()} registros encontrados";
                return response;
            } catch (Exception)
            {

                throw;
            }
        }
    }
}
