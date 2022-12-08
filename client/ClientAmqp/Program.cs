using ClientAmqp;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<AmqpData>();
    })
    .Build();

await host.RunAsync();
