using System.Collections.Generic;
using System.Web;
using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repository;
using Services.Interfaces;
using Services.Models;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public BusinessInfo GetBusinessInfoByEmail(string email)
        {
            var businessInfoEntity = _userRepository.GetBusinessInfoByEmail(email);
            return businessInfoEntity;
        }

        public List<ApplicationUser> GetAllBusinesses()
        {
            return _userRepository.GetAllBusinesses();
        }

        public List<BusinessInfo> GetAllBusinessesInfo()
        {
            return _userRepository.GetAllBusinessesInfo();
        }
    }
}
