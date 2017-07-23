using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Services.Models;

namespace Services.Interfaces
{
    public interface ICustomerInfoService
    {
        CustomerInfo GetCustomerInfoByEmail(string email);
        ServiceResponse CreateCustomerInfo(string userId);
    }
}
