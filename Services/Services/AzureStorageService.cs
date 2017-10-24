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
        private static readonly string AccountName = ConfigurationManager.AppSettings["StorageAccountName"];
        private static readonly string AccessKey = ConfigurationManager.AppSettings["StorageAccountKey"];
        private static readonly string MenusContainerName = ConfigurationManager.AppSettings["MenusContainerName"];
        private CloudBlobClient _blobClient;

        public AzureStorageService()
        {
            _businessService = new BusinessService();
        }

        private void IntiateStorageConnection()
        {
            var creds = new StorageCredentials(AccountName, AccessKey);
            var storageAccount = new CloudStorageAccount(creds, useHttps: true);
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public void UploadToBlobStorage(HttpPostedFileBase file, string businessInfoId)
        {
            IntiateStorageConnection();

            CloudBlobContainer container = _blobClient.GetContainerReference(MenusContainerName);

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
