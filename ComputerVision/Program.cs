using ComputerVisionLib;

string Url = "https://cdn.pixabay.com/photo/2015/08/12/10/20/person-885698_960_720.jpg";

Console.WriteLine("Inicio do Programa");

Console.WriteLine("Enviando Imagem para analise");

var descricoes = new ComputerVisionService().DescribeImage(Url);

Console.WriteLine("Exibindo analise");
descricoes.ForEach(d => Console.WriteLine(d));

Console.WriteLine("Termino do Programa");

