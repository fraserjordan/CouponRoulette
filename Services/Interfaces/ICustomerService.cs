using Data.Entities;
using Services.Models;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerInfo GetCustomerInfoByEmail(string email);
        ServiceResponse CreateCustomerInfo(string userId);
    }
}
