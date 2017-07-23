using System.Collections.Generic;

namespace Customer.Models
{
    public class IndexViewModel
    {
        public List<BusinessViewModel> Businesses { get; set; }

        public CustomerViewModel Customer { get; set; }
    }
}