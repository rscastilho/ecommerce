using Dapper;
using ecomm.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Data.Repositories
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        private readonly IConfiguration _configuration;

        public RepositoryGeneric(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(DynamicParameters parameters, string query)
        {
            try
            {
                using( var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = await connection.ExecuteScalarAsync<int>(query, parameters);
                    return result;
                }
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(DynamicParameters parameters, string query)
        {
            try
            {
                using( var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = await connection.ExecuteAsync(query, parameters);
                    return result;
                }

            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> GetAllAsync(string query)
        {
            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = await connection.QueryAsync<T>(query);
                    return result.ToList();
                }
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetByEmailAsync(DynamicParameters parameters, string query)
        {
            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = await connection.QueryFirstOrDefaultAsync<T>(query, parameters);
                    return result;

                }
            } catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetByIdAsync(DynamicParameters parameters, string query)
        {
            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = await connection.QueryFirstOrDefaultAsync<T>(query, parameters);
                    return result;
                }
            } catch (Exception)
            {
                throw;
            }

        }


        public async Task<int> UpdateAsync(DynamicParameters parameters, string query)
        {
            try
            {
                using( var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var result = await connection.ExecuteAsync(query, parameters);
                    return result;
                }
            } catch (Exception)
            {

                throw;
            }
        }
    }
}
