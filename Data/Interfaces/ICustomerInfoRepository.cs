using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface ICustomerInfoRepository
    {
        CustomerInfo GetCustomerInfoByEmail(string email);
        bool CreateCustomerInfo(string userId);
    }
}
