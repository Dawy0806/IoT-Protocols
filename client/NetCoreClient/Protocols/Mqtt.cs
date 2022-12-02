using MQTTnet;
using MQTTnet.Client;
using System;
using NetCoreClient.Interfacce;

namespace NetCoreClient.Protocols
{
    class Mqtt : IProtocol
    {
        private string? _endPoint;
        private int _port;
        private string? _topic;
        private IMqttClient? _client;

        public Mqtt(string endPoint, string topic, int port)
        {
            this._endPoint = endPoint;
            this._topic = topic;
            this._port = port;
            Connection().GetAwaiter().GetResult();
        }


        //metodo per la connesione con il protocollo mqtt
        private async Task<MqttClientConnectResult> Connection()
        {
            var mqtt = new MqttFactory();
            _client = mqtt.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                             .WithClientId(Guid.NewGuid().ToString())
                             .WithTcpServer(_endPoint)
                             .WithCleanSession()
                             .Build();

            //var resultConnection = await _client.TryPingAsync();

            if (await _client.TryPingAsync())
            {
                return await _client.ConnectAsync(options, CancellationToken.None);
            }
            else
            {
              throw new Exception("errore di connessione, verificare se i dati sono giusti");  
            }
            
            
            //return client;
        }

        //metodo per mandare il messaggio
        public async void Send(string data)
        {
            //var client = await Connection();
            var message = new MqttApplicationMessageBuilder()
                                .WithTopic(_topic)
                                .WithPayload(data)
                                .WithRetainFlag(true)
                                .Build();

            if (_client is not null && _client.IsConnected)
            {
                await _client.PublishAsync(message, CancellationToken.None);
            }
            else
            {
                Console.WriteLine("errore nella pubblicazione del messaggio o problemi di connesione");
            }

        }
    }
}