using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Demo.Interfaces
{
    public interface IUserAccountManager
    {
        Task<int> Login(string UserName, string UserPassword);
        Task<List<Model.User>> GetUsers();
    }
}
