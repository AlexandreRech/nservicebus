using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.Shared;

namespace NServiceBus.Client
{
    class Program
    {
        static void Main()
        {
            AsyncMain().GetAwaiter().GetResult();   
        }

        static async Task AsyncMain()
        {                    
            Console.Title = "Client";
                                                                        
            var endpointConfiguration = new EndpointConfiguration(
                endpointName: "NServiceBus.Client");

            endpointConfiguration.SendFailedMessagesTo("error");
                                                                        
            endpointConfiguration.UseSerialization<JsonSerializer>();
                                                                        
            endpointConfiguration.EnableInstallers();
                                                                        
            endpointConfiguration.UseTransport<LearningTransport>();
                                                                        
            endpointConfiguration.UsePersistence<LearningPersistence>();
                                                                        
            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);
            try
            {
                await SendOrder(endpointInstance)
                    .ConfigureAwait(false);
            }
            finally
            {
                await endpointInstance.Stop()
                    .ConfigureAwait(false);
            }
        }

        static async Task SendOrder(IEndpointInstance endpointInstance)
        {
            Console.WriteLine("Digite o nome do produto");

            while (true)
            {
                var nomeProduto = Console.ReadLine();

                var id = Guid.NewGuid();

                var placeOrder = new PlaceOrder
                {
                    Product = nomeProduto,
                    Id = id
                };

                await endpointInstance.Send("NServiceBus.Server", placeOrder)
                    .ConfigureAwait(false);

                Console.WriteLine($"Enviada ordem com id: {id:N}");

                Console.WriteLine("Digite 'S' para sair ou qualquer outra tecla para continuar.");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.S)
                    return;

                Console.WriteLine("Digite o nome do produto");
            }
        }
    }
}
