using Dapper;
using ecomm.Data.Queries;
using ecomm.Data.Validations;
using ecomm.Domain.Interfaces;
using ecomm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Data.Functions.UserFunctions
{
    public class UserFunctions : IUserFunctions<UserModel>
    {
        private readonly IUserRepository _userRepository;

        public UserFunctions(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> addUser(UserModel user)
        {
            try
            {
                UserQueries query = new();
                HashPassword hash = new();
                var parameters = new DynamicParameters();
                parameters.Add("@createdat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                parameters.Add("@name", user.Name);
                parameters.Add("@email", user.Email);
                string passwordHash = hash.HasherPassword(user.Password); 
                parameters.Add("@password", passwordHash);
                
                var result = await _userRepository.AddAsync(parameters, query.add());
                return result;

            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            try
            {
                UserQueries query = new();
                List<UserModel> result = await _userRepository.GetAllAsync(query.ListAll());

                return result;

            } catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserModel> getUserByEmail(string email)
        {
            try
            {
                UserQueries query = new();
                var parameters = new DynamicParameters();
                parameters.Add("@email", email.ToString());
                UserModel result = await _userRepository.GetByIdAsync(parameters, query.byEmail());
                return result;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserModel> getUserById(int id)
        {
            try
            {
                UserQueries query = new();
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                UserModel result = await _userRepository.GetByIdAsync(parameters, query.byid());
                return result;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserModel> Login(string email, string password)
        {
            try
            {
                UserQueries query = new();
                var parameters = new DynamicParameters();
                parameters.Add("@email", email.ToString());
                UserModel result = await _userRepository.GetByIdAsync(parameters, query.byEmail());
                
                return result;

            } catch (Exception)
            {

                throw;
            }
        }
    }
}
