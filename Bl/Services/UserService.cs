using Bl.Services.Interfaces;
using Dal.models;
using Dal.Repositories;
using System;

namespace Bl.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            try
            {
                _userRepository.CreateUser(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("שגיאה בעת יצירת משתמש חדש.", ex);
            }
        }

       
        public bool UserExists(User user)
        {
            try
            {
                return _userRepository.UserExists(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("שגיאה בעת בדיקת קיום המשתמש.", ex);
            }
        }

        
        
        public List<string> GetResponsesByUserId(int userId)
        {
            try
            {
                return _userRepository.GetResponsesByUserId(userId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("שגיאה בעת שליפת התגובות של המשתמש.", ex);
            }
        }
    }
}
