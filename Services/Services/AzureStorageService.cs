using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Services.Interfaces;

namespace Services.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly IBusinessService _businessService;
        private static readonly string accountName = "fraserteststorage";
        private static readonly string accessKey = "cOG5ee85cfrN4FbtT6bANeP+zDD03UFb21VwH7/yig3egL7DaNPkunXYuampjevHXY+NXx0DBMASEtFz4iu7Eg==";
        private static readonly string menusContainerName = "freecouponsmenus";
        private readonly CloudBlobClient _blobClient;

        public AzureStorageService()
        {
            _businessService = new BusinessService();
            var creds = new StorageCredentials(accountName, accessKey);
            var storageAccount = new CloudStorageAccount(creds, useHttps: true);
            _blobClient = storageAccount.CreateCloudBlobClient();

        }

        public void UploadToBlobStorage(HttpPostedFileBase file, string businessInfoId)
        {
            CloudBlobContainer container = _blobClient.GetContainerReference(menusContainerName);

            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(businessInfoId + ".pdf");
            blockBlob.UploadFromStream(file.InputStream);
            _businessService.UpdateMenuUrl(int.Parse(businessInfoId), blockBlob.Uri.ToString());
        }
    }
}
