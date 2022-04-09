namespace api_upload_image_azure.Services.Interface
{
    public interface IFileUploadService
    {
        string UploadBase64Image(string base64Image, string container);
    }
}
