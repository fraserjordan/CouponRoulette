using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services.Interfaces
{
    public interface IAzureStorageService
    {
        void UploadToBlobStorage(HttpPostedFileBase file, string businessInfoId);
    }
}
