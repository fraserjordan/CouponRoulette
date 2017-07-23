using System;
using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repository;
using Services.Models;

namespace Services.Services
{
    public class BusinessInfoService : IBusinessInfoService
    {
        private readonly IBusinessInfoRepository _businessInfoRepository;
        public BusinessInfoService()
        {
            _businessInfoRepository = new BusinessInfoRepository();
        }

        public ServiceResponse CreateBusinessInfo(string userId, string businessName, double lat, double lng, string formattedAddress, string phoneNumber, string formattedPhoneNumber, string website, double rating, string placeId)
        {
            var response = new ServiceResponse();
            try
            {
                response.Success = _businessInfoRepository.CreateBusinessInfo(userId, businessName, lat, lng, formattedAddress, phoneNumber, formattedPhoneNumber, website, rating, placeId);
            }
            catch (Exception e)
            {
                response.Success = false;
            }
            response.Messages.Add(response.Success ? ReturnMessages.UpdateBusinessInfoSuccess : ReturnMessages.UpdateBusinessInfoError);
            return response;
        }

        public BusinessInfo GetBusinessInfo(string userId)
        {
            try
            {
                return _businessInfoRepository.GetBusinessInfo(userId);
            }
            catch (Exception e)
            {
                // log getting business info error
                return null;
            }
        }

        public ServiceResponse UpdateBusinessInfo(string email, BusinessInfoServiceModel businessInfo)
        {
            var response = new ServiceResponse();
            try
            {
                var businessInfoEntity = Mapper.Map<BusinessInfo>(businessInfo);
                response.Success = _businessInfoRepository.UpdateBusinessInfo(email, businessInfoEntity);
            }
            catch (Exception e)
            {
                response.Success = false;
                // log error updateing google info
            }
            response.Messages.Add(response.Success ? ReturnMessages.UpdateBusinessInfoSuccess : ReturnMessages.UpdateBusinessInfoError);
            return response;
        }

        public ServiceResponse VerifyPhysicalAddressCode(string email, string code)
        {
            var response = new ServiceResponse();
            try
            {
                response.Success = _businessInfoRepository.VerifyAddressCode(email, code);
            }
            catch (Exception e)
            {
                response.Success = false;
            }
            response.Messages.Add(response.Success ? ReturnMessages.VerifyPhysicalAddressSuccess : ReturnMessages.VerifyPhysicalAddressError);
            return response;
        }

        public ServiceResponse UpdateMenuUrl(int businessInfoId, string menuUrl)
        {
            var response = new ServiceResponse();

            try
            {
                response.Success = _businessInfoRepository.UpdateMenuUrl(businessInfoId, menuUrl);
                response.Messages.Add(ReturnMessages.UploadMenuSuccess);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Messages.Add(ReturnMessages.UploadMenuError);
            }
            return response;
        }

        public BusinessInfo GetBusinessInfoByEmail(string email)
        {
            var businessInfoEntity = _businessInfoRepository.GetBusinessInfoByEmail(email);
            return businessInfoEntity;
        
        }
    }
}
