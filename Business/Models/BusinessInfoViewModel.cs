using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Models
{
    public class BusinessInfoViewModel
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
        public string MenuUrl { get; set; }
    }
}