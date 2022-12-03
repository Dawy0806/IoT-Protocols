using MQTTnet;
using MQTTnet.Client;
using System;
using NetCoreClient.Interfacce;

namespace NetCoreClient.Protocols
{
    class Mqtt : IProtocol
    {
        private string? _endPoint;
        private string? _topic;
        private IMqttClient? _client;
        private string? _lastWillTopic;
        private string? _lastWillMessageTopic;
        private TimeSpan _keepAlive;
        private int? _port;

        public Mqtt(string endPoint, string topic, int port, TimeSpan keepAlive, string lastWillTopic)
        {
            this._endPoint = endPoint;
            this._topic = topic;
            this._port = port;
            this._keepAlive = keepAlive;
            this._lastWillTopic = lastWillTopic;
            this._lastWillMessageTopic = "disconessione/problemi al drone";
            Connection().GetAwaiter().GetResult();
        }


        //metodo per la connesione con il protocollo mqtt
        private async Task<MqttClientConnectResult> Connection()
        {

            // try
            // {
            //     var mqtt = new MqttFactory();
            //     _client = mqtt.CreateMqttClient();
            //     var options = new MqttClientOptionsBuilder()
            //                      .WithClientId(Guid.NewGuid().ToString())
            //                      .WithTcpServer(_endPoint, _port)
            //                      .WithCleanSession()
            //                      .Build();
            //     return await _client.ConnectAsync(options, CancellationToken.None);
            // }
            // catch (System.Exception)
            // {

            //     throw new Exception("errore di connessione, verificare se i dati sono giusti");
            // }

            var mqtt = new MqttFactory();
            _client = mqtt.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                             .WithClientId(Guid.NewGuid().ToString())
                             .WithTcpServer(_endPoint, _port)
                             .WithCleanSession(true)
                             //utilizzo questo perchè garantisce che i messaggi inviati arrivino almeno una volta
                             //in questo caso per monitorare i drone secondo me va bene perche possimao monitorare con piu precisione 
                             //i dati di un importana superiore come altitudine, batteria ....
                             //inoltre e il livello piu veloce 
                             .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce) 
                             //utile per verificare se il drone è effetivamente attivo oppure e successo qualcossa
                             //perche con questo posso specificare quanto tempo deve passare per ricevere un messaggio
                             .WithKeepAlivePeriod(_keepAlive)
                             //secondo me utili al fine di avere un messaggio per esempio di errore o disconnesione in un canale private 
                             .WithWillTopic(_lastWillTopic)
                             //utile al fine di comunicare un messaggio in caso di disconessione o malfunzionamento del drone
                             .WithWillPayload(_lastWillMessageTopic)
                             .Build();

            
            while (true)
            {
                try
                {
                    if (!await _client.TryPingAsync())
                    {
                        return await _client.ConnectAsync(options, CancellationToken.None);
                    }
                }
                catch
                {

                }
                finally
                {
                    //controllo dello stato della connesione ogni 5 secondi e se serve mi riconnetto
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
        }
        //metodo per mandare il messaggio
        public async void Send(string data)
        {
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