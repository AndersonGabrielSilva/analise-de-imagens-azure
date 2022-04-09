using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace ComputerVisionLib
{
    public class ComputerVisionService
    {
        private string _key = "minha chave privada";
        private string _endpoint = "url do meu serviço de cognitive service da azure";
        
        public List<string> DescribeImage(string imageUrl, int maximoDescricoes = 3, string idioma = "pt")
        {
            var result = new List<string>();

            try
            {
                ComputerVisionClient computerVision = new ComputerVisionClient(new ApiKeyServiceClientCredentials(_key))
                { Endpoint = _endpoint };

                var analises = computerVision.DescribeImageAsync(imageUrl, maximoDescricoes, idioma).GetAwaiter().GetResult();

                // Descricoes da Imagem
                foreach (var item in analises.Captions)
                    result.Add($"{item.Text}, {item.Confidence}");

            }
            catch (Exception ex)
            {
                result.Add($"Erro ao descrever a Imagem: {imageUrl}");
            }

            return result;
        }
    }
}