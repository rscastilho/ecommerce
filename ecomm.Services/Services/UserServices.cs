using AutoMapper;
using ecomm.Data.Functions.UserFunctions;
using ecomm.Data.Validations;
using ecomm.Domain.Dtos.User;
using ecomm.Domain.IServices;
using ecomm.Domain.Models;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
                

        public UserServices(IUserFunctions<UserModel> userFunction, IConfiguration configuration, IMapper mapper)
        {
            _userFunction = userFunction;
            _configuration = configuration;
            _mapper = mapper;
        
        }

        public async Task<ResponseModel<UserAddDto>> addUser(UserAddDto user)
        {
            try
            {
                ResponseModel<UserAddDto> response = new();


                if(user is null)
                {
                    response.Data = null;
                    response.Message = "Preencha todos os campos obrigatórios";
                    return response;
                }

                var userMap = _mapper.Map<UserModel>(user);
                var userExist = await _userFunction.getUserByEmail(user.Email);
                if (userExist is not null)
                {
                    response.Message = $"{user.Email} email já cadastrado";
                    response.Data = user;
                    return response;
                }


                var result = await _userFunction.addUser(userMap);
                if(result == null)
                {
                    response.Data = null;
                    response.Message = "Erro ao cadastrar usuário";
                    return response;
                }

                var userEmailMap = _mapper.Map<UserAddDto>(user);
                var userByEmail = await _userFunction.getUserById(result);
                response.Data = userEmailMap;
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

        public async Task<ResponseModel<UserModel>> Login(UserModel user)
        {
            try
            {
                ResponseModel<UserModel> response = new();
                var result = await _userFunction.Login(user.Email, user.Password);

                if(result is null)
                {
                    response.Data =null;
                    response.Message = $"usuário {user.Name} não cadastrado";
                    return response;
                }

                ValidaPassword checkpassword = new();
                bool validaSenha = checkpassword.ComparePassword(user.Password, result.Password);
                if (!validaSenha)
                {
                    response.Message = $"Senha incorreta, tente novamente";
                    return response;
                    
                }

                createToken gerar = new();
                var token = gerar.generateToken(user, _configuration["secretKey"]);
                
                response.Data = result;
                response.Message = $"token: {token}";
                return response;


            } catch (Exception)
            {

                throw;
            }
        }
    }
}
