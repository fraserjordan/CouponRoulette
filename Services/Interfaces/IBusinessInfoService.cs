using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Services.Models;

namespace Services
{
    public interface IBusinessInfoService
    {
        BusinessInfo GetBusinessInfoByEmail(string email);
        ServiceResponse CreateBusinessInfo(string userId, string businessName, double lat, double lng, string formattedAddress, string phoneNumber, string formattedPhoneNumber, string website, double rating, string placeId);
        BusinessInfo GetBusinessInfo(string userId);
        ServiceResponse UpdateBusinessInfo(string email, BusinessInfoServiceModel businessInfo);
        ServiceResponse VerifyPhysicalAddressCode(string email, string code);

        ServiceResponse UpdateMenuUrl(int businessInfoId, string menuUrl);
    }
}
