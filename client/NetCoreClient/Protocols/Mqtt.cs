
using MQTTnet;
using MQTTnet.Client;
using System;
using NetCoreClient.Interfacce;

namespace NetCoreClient.Protocols
{
    class Mqtt : IProtocol
    {

        private string endPoint;
        private IMqttClient mqttClient;
        private int port;
        private string topic;

        public Mqtt(string endPoint, string topic, int port)
        {
            this.endPoint = endPoint;
            this.topic = topic;
            this.port = port;
            Connection().GetAwaiter().GetResult();
        }

        //metodo per la connesione con il protocollo mqtt
        private async Task<MqttClientConnectResult> Connection()
        {
            var mqtt = new MqttFactory();
            var client = mqtt.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                             .WithClientId(Guid.NewGuid().ToString())
                             .WithTcpServer(endPoint, port)
                             .WithCleanSession()
                             .Build();
            return await client.ConnectAsync(options);
        }


        //metodo per mandare il messaggio
        public async void Send(string data)
        {
            var client = Connection();
            var message = new MqttApplicationMessageBuilder()
                                .WithTopic(topic)
                                .WithPayload(data)
                                .Build();
            await mqttClient.PublishAsync(message, CancellationToken.None);
        }
    }
}