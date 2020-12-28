using OrderManagement.Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Demo.Manager
{
    public class UserAccountManager: IUserAccountManager
    {
        private IUserAccountRepository _userAccountRepository;

        public UserAccountManager(IUserAccountRepository userAccountRepository)
        {            
            _userAccountRepository = userAccountRepository;
        }
        public async Task<int> Login(string UserName, string UserPassword)
        {
            var users = await GetUsers();
            users = users.Where(u => u.UserName == UserName && u.Password == UserPassword).ToList();
            return (users != null && users.Count > 0) ? users.FirstOrDefault().UserId : 0;
        }
        public async Task<List<Model.User>> GetUsers()
        {
            var users = await _userAccountRepository.GetUsers().ConfigureAwait(false);
            return users.ToList();
        }
    }
}
