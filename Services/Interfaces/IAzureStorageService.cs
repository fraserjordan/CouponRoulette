using System.Web;

namespace Services.Interfaces
{
    public interface IAzureStorageService
    {
        string UploadToBlobStorage(HttpPostedFileBase file, int businessInfoId);
    }
}
