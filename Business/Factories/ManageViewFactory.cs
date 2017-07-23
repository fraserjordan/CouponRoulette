using AutoMapper;
using Business.Models;
using Data.Entities;
using Services.Models;

namespace Business.Factories
{
    public class ManageViewFactory
    {
        public BusinessInfoViewModel CreateIndexViewModel(BusinessInfo bussinessInfo)
        {
            var model = Mapper.Map<BusinessInfoViewModel>(bussinessInfo);
            return model;
        }
    }
}