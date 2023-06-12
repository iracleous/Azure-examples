using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;


namespace az204_blob;

public static class Storage
{
    static public async Task DoWork()
    {
        Console.WriteLine("Azure Blob Storage exercise\n");

        // Run the examples asynchronously, wait for the results before proceeding
        Task task =  ProcessAsync();
       await task  ;

        Console.WriteLine("Press enter to exit the sample application.");
        Console.ReadLine();
    }

    static async Task ProcessAsync()
    {

        string connectionString = "DefaultEndpointsProtocol=https;AccountName=metrostorageaccount20023;AccountKey=r0D3j4UhykTEr7b1cfA9NK5yf1EGpPx6Ae1Ezt5kgqCnO60U0e2e9ABQKHD5ilS/x+DhjlNX12ij+ASttsjiEA==;EndpointSuffix=core.windows.net";

        // Copy the connection string from the portal in the variable below.
        string storageConnectionString = connectionString;

        // Create a client that can authenticate with a connection string
        BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);

        //1. container

        // Create a unique name for the container
        string containerName = "wtblob" + Guid.NewGuid().ToString();

        // Create the container and return a container client object
        BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
        Console.WriteLine("A container named '" + containerName + "' has been created. " +
            "\nTake a minute and verify in the portal." +
            "\nNext a file will be created and uploaded to the container.");
        Console.WriteLine("Press 'Enter' to continue.");
        Console.ReadLine();

        //2. upload
        // Create a local file in the ./data/ directory for uploading and downloading
        string localPath = "./";
        string fileName = "wtfile" + Guid.NewGuid().ToString() + ".txt";
        string localFilePath = Path.Combine(localPath, fileName);

        // Write text to the file
        await File.WriteAllTextAsync(localFilePath, "Hello, World!");

        // Get a reference to the blob
        BlobClient blobClient = containerClient.GetBlobClient(fileName);

        Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

        // Open the file and upload its data
        using (FileStream uploadFileStream = File.OpenRead(localFilePath))
        {
            await blobClient.UploadAsync(uploadFileStream);
            uploadFileStream.Close();
        }

        Console.WriteLine("\nThe file was uploaded. We'll verify by listing" +
                " the blobs next.");
        Console.WriteLine("Press 'Enter' to continue.");
        Console.ReadLine();


        // List blobs in the container
        Console.WriteLine("Listing blobs...");
        await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
        {
            Console.WriteLine("\t" + blobItem.Name);
        }

        Console.WriteLine("\nYou can also verify by looking inside the " +
                "container in the portal." +
                "\nNext the blob will be downloaded with an altered file name.");
        Console.WriteLine("Press 'Enter' to continue.");
        Console.ReadLine();

    }





}
