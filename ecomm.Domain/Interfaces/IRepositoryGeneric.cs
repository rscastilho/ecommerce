using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Domain.Interfaces
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<List<T>> GetAllAsync(string query);
        Task<T> GetByIdAsync(DynamicParameters parameters, string query);
        Task<T> GetByEmailAsync(DynamicParameters parameters, string query);
        Task<int> AddAsync(DynamicParameters parameters, string query);
        Task<int> UpdateAsync(DynamicParameters parameters, string query);
        Task<int> DeleteAsync(DynamicParameters parameters, string query);

    }
}
