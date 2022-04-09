using System;
using System.IO;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ImagemAdicionada
{
    public class FileUploadTriggerFunc
    {

        [FunctionName("upload-image")]
        [StorageAccount("AzureWebJobsStorage")]
        public void Run([BlobTrigger("analise-imagens/{name}", Connection = "AzureWebJobsStorage")]BlobClient blobCLient, string name, ILogger log)
        {
            log.LogInformation($"Blob adicionado \n Name:{name} \n");
         
            log.LogInformation("URL: " + blobCLient.Uri.AbsoluteUri);


        }
    }
}
