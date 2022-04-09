using api_upload_image_azure.Services.Interface;
using Azure.Storage.Blobs;
using System.Text.RegularExpressions;

namespace api_upload_image_azure.Services
{
    public class FileUploadService : IFileUploadService
    {
        private IConfiguration _configuration { get; }
        public FileUploadService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string UploadBase64Image(string base64Image, string container)
        {
            var _connectionString = _configuration.GetSection("AzureStorage").GetSection("ConnectionString")?.Value;

            // Gera um nome randomico para imagem
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // Limpa o hash enviado 
            // Pois se sentar converter para um array de bytes com as informaçoes do base 64 irá dar erro
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            // Gera um array de Bytes
            var imageBytes = Convert.FromBase64String(data);

            // Define o BLOB no qual a imagem será armazenada
            var blobCliente = new BlobClient(_connectionString, container, fileName);

            // Enviar a Imagem 
            using (var stream = new MemoryStream(imageBytes))
            {
                blobCliente.Upload(stream);
            };

            //Retorna a URL da Imagem
            return blobCliente.Uri.AbsoluteUri;
        }

    }
}
