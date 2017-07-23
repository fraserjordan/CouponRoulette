using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ServiceResponse
    {
        public ServiceResponse()
        {
            Messages = new List<string>();
        }

        public bool Success { get; set; }

        public List<string> Messages { get; set; }
    }
}
