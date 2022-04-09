namespace api_upload_image_azure.Command
{
    public class UploadImageCommand
    {
        //Nome do Containner 
        public string Container { get; set; }
        
        //Imagem no formato base64
        public string ImageBase64 { get; set; }
    }
}
