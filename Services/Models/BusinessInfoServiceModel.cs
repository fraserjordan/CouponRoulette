﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace Services.Models
{
    public class BusinessInfoServiceModel
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string FormattedAddress { get; set; }
        public string FormattedPhoneNumber { get; set; }
        public string InternationalPhoneNumber { get; set; }
        public string GooglePlaceId { get; set; }
        public string WebsiteUrl { get; set; }
        public double Rating { get; set; }
        public AddressVerificationStatus AddressVerificationStatus { get; set; }
        public string AddressVerificationCode { get; set; }
    }
}