﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Customer.Models;
using Data.Enums;
using Services.Interfaces;
using Services.Services;

namespace Customer.Factories
{
    public class HomeViewFactory
    {
        private readonly IUserService _userService;

        public HomeViewFactory()
        {
            _userService = new UserService();
        }

        public IndexViewModel CreateIndexViewModel()
        {
            var model = new IndexViewModel();
            var businessesInfo = _userService.GetAllBusinessesInfo().Where(x => x.AddressVerificationStatus == AddressVerificationStatus.Verified);
            model.Businesses = Mapper.Map<List<BusinessViewModel>>(businessesInfo);
            return model;
        }
    }
}