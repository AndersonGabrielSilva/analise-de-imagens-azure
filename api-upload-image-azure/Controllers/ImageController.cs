using api_upload_image_azure.Command;
using api_upload_image_azure.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api_upload_image_azure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        public IFileUploadService UploadService { get; }
        public ImageController(IFileUploadService uploadService)
        {
            UploadService = uploadService;
        }


        [HttpPost("upload")]
        public string UploadImage([FromBody] UploadImageCommand uploadImage)
        {
            //return UploadService.UploadBase64Image(uploadImage.Image, uploadImage.Container);
            return UploadService.UploadBase64Image(uploadImage.ImageBase64, "analise-imagens");
        }
    }
}
