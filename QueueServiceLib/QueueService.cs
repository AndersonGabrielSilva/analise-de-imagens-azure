using Azure.Storage.Queues;

namespace QueueServiceLib.Service
{
    public class QueueService
    {
        private string _connectionString = "Url da Conta de Armazenamento";
        public void SendMessage(string mensagem, string queueName = "imagem-processada")
        {
            try
            {
                var queueCliente = new QueueClient(_connectionString, queueName);
                queueCliente.SendMessage(mensagem);
            }
            catch
            {}
        }
    }
}