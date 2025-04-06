using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Data.Queries
{
    public class UserQueries
    {

        public string ListAll()
        {
            string query = @"select * from user";
            return query;
        }

        public string add()
        {
            string query = @"insert into user (createdat, name, email, password) values (@createdat,@name, @email, @password); select last_insert_id()";
            return query;
        }

        public string byid()
        {
            string query = @"select * from user where id = @id";
            return query;
        }

        public string byEmail()
        {
            string query = @"select * from user where email = @email";
            return query;
        }
    }
}
