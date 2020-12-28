using System;
using System.Threading.Tasks;

namespace OrderManagement.Demo.Interfaces
{
    public interface IEmailManager
    {
        Task<bool> SendEmail(string to, string from, string body, string subject);
    }
}
