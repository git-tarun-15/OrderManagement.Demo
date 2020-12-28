using OrderManagement.Demo.Interfaces;
using OrderManagement.Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Demo.DataAccess
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly string _connectionString;
        public UserAccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>
                            {
                                new User { UserId = 1, UserName="admin", Password="admin", UserEmail="admin@test.com" },
                                new User { UserId = 2, UserName="admin1", Password="admin1", UserEmail="admin1@test.com" },
                                new User { UserId = 3, UserName="admin2", Password="admin2", UserEmail="admin2@test.com" },
                                new User { UserId = 4, UserName="admin3", Password="admin3", UserEmail="admin3@test.com" },
                                new User { UserId = 5, UserName="admin4", Password="admin4", UserEmail="admin4@test.com" }
                            };
            return await Task.FromResult(users);
        }
    }
}
