# nservicebus
Exemplo de uso de NServiceBus, uma ferramenta de barramento de serviço.

# O que é um barramento de serviço:
Um barramento de serviço é utilizado quando três ou mais aplicações precisam ser integradas de maneira orquestrada. Essa integração independe da linguagem usada para o desenvolvimento de cada aplicação, pois a mesma se dá por meio de mensagens.
O protocolo de orientação a mensagens, facilitado pelo uso de barramentos de serviço, possibilitam a arquitetura orientada a serviços (SOA), ao proporcionar a comunicação entre serviços.

No exemplo do meu portfólio, temos um client no qual é possível fazer pedidos. O server recebe esses pedidos e cada pedido é monitorado por um subscriber, que o publica.
