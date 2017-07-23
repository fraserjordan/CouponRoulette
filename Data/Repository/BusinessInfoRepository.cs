using System;
using System.Linq;
using Data.Entities;
using Data.Enums;
using Data.Interfaces;

namespace Data.Repository
{
    public class BusinessInfoRepository : IBusinessInfoRepository
    {
        private readonly DataContext _context;
        public BusinessInfoRepository()
        {
            _context = new DataContext();
        }

        public bool CreateBusinessInfo(string userId, string businessName, double lat, double lng, string formattedAddress, string phoneNumber, string formattedPhoneNumber, string website, double rating, string placeId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                var businessInfo = new BusinessInfo()
                {
                    BusinessName = businessName,
                    Lat = lat,
                    Lng = lng,
                    FormattedAddress = formattedAddress,
                    InternationalPhoneNumber = phoneNumber,
                    FormattedPhoneNumber = formattedPhoneNumber,
                    WebsiteUrl = website,
                    Rating = rating,
                    GooglePlaceId = placeId,
                    AddressVerificationStatus = AddressVerificationStatus.PendingVerification,
                    AddressVerificationCode = RandomDigits(10)
                };
                user.BusinessInfo = businessInfo;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        public BusinessInfo GetBusinessInfo(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            return user?.BusinessInfo;
        }

        public bool UpdateBusinessInfo(string email, BusinessInfo businessInfo)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);

            if (user != null)
            {
                user.BusinessInfo.BusinessName = businessInfo.BusinessName;
                user.BusinessInfo.FormattedAddress = businessInfo.FormattedAddress;
                user.BusinessInfo.FormattedPhoneNumber = businessInfo.FormattedPhoneNumber;
                user.BusinessInfo.InternationalPhoneNumber = businessInfo.InternationalPhoneNumber;
                user.BusinessInfo.Lat = businessInfo.Lat;
                user.BusinessInfo.Lng = businessInfo.Lng;
                user.BusinessInfo.WebsiteUrl = businessInfo.WebsiteUrl;
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool VerifyAddressCode(string email, string code)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);

            if (user?.BusinessInfo.AddressVerificationCode == code)
            {
                user.BusinessInfo.AddressVerificationStatus = AddressVerificationStatus.Verified;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool UpdateMenuUrl(int businessInfoId, string menuUrl)
        {
            var user = _context.Users.FirstOrDefault(x => x.BusinessInfo.Id == businessInfoId);
            if (user == null) return false;
            user.BusinessInfo.MenuUrl = menuUrl;
            return _context.SaveChanges() > 0;
        }

        public BusinessInfo GetBusinessInfoByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            return user?.BusinessInfo;
        }
    }
}
