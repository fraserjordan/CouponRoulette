using Data.Entities;

namespace Data.Interfaces
{
    public interface IBusinessRepository
    {
        bool CreateBusinessInfo(string userId, string businessName, double lat, double lng, string formattedAddress, string phoneNumber, string formattedPhoneNumber, string website, double rating, string placeId);
        BusinessInfo GetBusinessInfo(string userId);
        bool UpdateBusinessInfo(string email, BusinessInfo businessInfo);
        bool VerifyAddressCode(string email, string code);
        bool UpdateMenuUrl(int businessInfoId, string menuUrl);
        BusinessInfo GetBusinessInfoByEmail(string email);
    }
}
