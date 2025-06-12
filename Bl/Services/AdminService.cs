using Bl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.models;
using Dal.Repositories;


namespace Bl.Services
{
    public class AdminService : IAdminService
    {
        private readonly AdminRepository _adminRepository;

        public AdminService(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _adminRepository.GetAllUsers();
        }
    }
}
