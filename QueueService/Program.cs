using QueueServiceLib.Service;

Console.WriteLine("Inicio do Programa");

Console.WriteLine("Iniciando Cliente da Queue");
var queueService =  new QueueService();

Console.WriteLine("Enviando Mensagem");

queueService.SendMessage("Teste Queue 2107");
Console.WriteLine("Termino do Programa");