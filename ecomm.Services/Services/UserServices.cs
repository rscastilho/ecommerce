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


                if (user is null)
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
                if (result == null)
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

        public async Task<ResponseModel<List<UserGetAllDto>>> GetAllUsers()
        {
            try
            {
                ResponseModel<List<UserGetAllDto>> response = new();
                var result = await _userFunction.GetAllUsers();
                var usersMap = _mapper.Map<List<UserGetAllDto>>(result);
                if (result.Count == 0)
                {
                    response.Data = null;
                    response.Message = "Nenhum usuário encontrado";
                    return response;
                }
                response.Data = usersMap;
                response.Message = $"{result.Count()} registros encontrados";
                return response;
            } catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseModel<UserLogonDto>> Login(UserLoginDto user)
        {
            try
            {
                //instancia de retorno
                ResponseModel<UserLogonDto> response = new();
                //busca usuario e senha no banco
                var result = await _userFunction.Login(user.Email, user.Password);
                //verifica se os dados acima existem
                if (result is null)
                {
                    response.Data = null;
                    response.Message = $"usuário {user.Email} não cadastrado";
                    return response;
                }
                //mapeia o carregamento do banco para model usuario completo
                var userMap = _mapper.Map<UserModel>(result);
                //instancia de validação da senha
                ValidaPassword checkpassword = new();
                bool validaSenha = checkpassword.ComparePassword(user.Password, result.Password);
                if (!validaSenha)
                {
                    response.Message = $"Senha incorreta, tente novamente";
                    return response;
                }

                //criacao do token jwt com o usario mapeado trazendo o name e email para o token
                createToken gerar = new();
                //var token = gerar.generateToken(userMap, _configuration["secretKey"]);
                var token = gerar.generateToken(userMap, _configuration.GetSection("jwt:token").Value);

                //converte os dados carregados para uselogon e retorna no response instanciado
                var userMapReverse = _mapper.Map<UserLogonDto>(result);

                response.Data = userMapReverse;
                response.Message = $"{token}";
                return response;


            } catch (Exception)
            {

                throw;
            }
        }
    }
}
