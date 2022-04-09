using System.Text.Json;
using Azure.Storage.Blobs;
using ComputerVisionLib;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using QueueServiceLib.Service;

namespace ImagemAdicionada
{
    public class FileUploadTriggerFunc
    {

        [FunctionName("upload-image")]
        [StorageAccount("AzureWebJobsStorage")]
        public void Run([BlobTrigger("analise-imagens/{name}", Connection = "AzureWebJobsStorage")] BlobClient blobCLient, string name, ILogger log)
        {
            log.LogInformation($"Blob adicionado \n Name:{name} \n");

            log.LogInformation("URL: " + blobCLient.Uri.AbsoluteUri);

            var descricoes = new ComputerVisionService().DescribeImage(blobCLient.Uri.AbsoluteUri);

            descricoes.ForEach(d =>log.LogInformation("Descricão: " + d));

            var queueService = new QueueService();
            var json = JsonSerializer.Serialize(descricoes);
            queueService.SendMessage($"Imagem: {name} descricao:{json}");
        }
    }
}
