using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Data.Validations
{
    public class ValidaPassword
    {
        public bool ComparePassword(string password, string passwordHash ) {
            bool validaSenha = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            return validaSenha;

        }
    }
}
