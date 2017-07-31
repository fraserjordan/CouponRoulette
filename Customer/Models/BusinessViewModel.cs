namespace Customer.Models
{
    public class BusinessViewModel
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
    }
}