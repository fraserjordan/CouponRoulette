using System.Web;

namespace Services.Interfaces
{
    public interface IAzureStorageService
    {
        void UploadToBlobStorage(HttpPostedFileBase file, string businessInfoId);
    }
}
