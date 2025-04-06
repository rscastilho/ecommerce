using Dapper;
using ecomm.Domain.Interfaces;
using ecomm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Data.Repositories
{
    public class UserRepository :IUserRepository

    {
        private readonly IRepositoryGeneric<UserModel> _userRepository;

        public UserRepository(IRepositoryGeneric<UserModel> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddAsync(DynamicParameters parameters, string query)
        {
            var result = await _userRepository.AddAsync(parameters, query);
            return result;
        }

        public Task<int> DeleteAsync(DynamicParameters parameters, string query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetAllAsync(string query)
        {
            var result = await _userRepository.GetAllAsync(query);
            return result;
        }

     
        public async Task<UserModel> GetByEmailAsync(DynamicParameters parameters, string query)
        {
            var result = await _userRepository.GetByEmailAsync(parameters, query);   
            return result;
        }

        public async Task<UserModel> GetByIdAsync(DynamicParameters parameters, string query)
        {
            var result = await _userRepository.GetByIdAsync(parameters, query);
            return result;
        }

        public Task<int> UpdateAsync(DynamicParameters parameters, string query)
        {
            throw new NotImplementedException();
        }
    }
}
