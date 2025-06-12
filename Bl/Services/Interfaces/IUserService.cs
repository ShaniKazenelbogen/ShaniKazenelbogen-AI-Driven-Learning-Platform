using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services.Interfaces
{
    public interface IUserService
    {
        public void RegisterUser(User user);
        bool UserExists(User user);
        public List<string> GetResponsesByUserId(int userId);
    }
}
