using System.Collections.Generic;
using Data.Entities;
using Services.Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        ApplicationUser GetUserByEmail(string email);
        List<ApplicationUser> GetAllBusinesses();
        List<BusinessInfo> GetAllBusinessesInfo();
        BusinessInfo GetBusinessInfoByEmail(string email);
    }
}
