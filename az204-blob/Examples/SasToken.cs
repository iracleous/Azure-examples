using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace az204_blob.Examples
{
    internal class SasToken
    {

        public string ConnectionString = "";
        public string Container = "";
        public string AccountName = "";
        public string AccountKey = "";

        public void DoWork()
        {

            BlobContainerClient container = new BlobContainerClient(ConnectionString, Container);
            foreach (BlobItem blobItem in container.GetBlobs())
            {
                BlobClient blob = container.GetBlobClient(blobItem.Name);

        BlobSasBuilder sas = new BlobSasBuilder
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name,
                Resource = "b",  //blob
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(1)
            };

            // Allow read access
            sas.SetPermissions(BlobSasPermissions.Read);


            StorageSharedKeyCredential storageSharedKeyCredential = new StorageSharedKeyCredential(AccountName, AccountKey);

           string  sasToken = sas.ToSasQueryParameters(storageSharedKeyCredential).ToString();
            }

    
            

        }


    }
}
