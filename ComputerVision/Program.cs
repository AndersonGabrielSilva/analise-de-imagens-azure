// See https://aka.ms/new-console-template for more information
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

Console.WriteLine("Hello, World!");

string Key = "minha chave privada";
string endpoint = "url do meu serviço de cognitive service da azure";
string Url = "https://cdn.pixabay.com/photo/2015/08/12/10/20/person-885698_960_720.jpg";

ComputerVisionClient computerVision = new ComputerVisionClient(new ApiKeyServiceClientCredentials(Key)) 
 { Endpoint = endpoint } ;

var analises = computerVision.DescribeImageAsync(Url, 10, "pt").GetAwaiter().GetResult();

foreach (var item in analises.Captions)
{
    Console.WriteLine($"{item.Text}, {item.Confidence}");
}
