using Data.Entities;

namespace Data.Interfaces
{
    public interface ICustomerRepository
    {
        CustomerInfo GetCustomerInfoByEmail(string email);
        bool CreateCustomerInfo(string userId);
    }
}
