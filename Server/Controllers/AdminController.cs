using Bl.Services.Interfaces;
using Dal.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bl.Services;
using Dal.Repositories;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("users")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _adminService.GetUsers();
            return Ok(users);
        }
    }
}
