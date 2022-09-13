# PocKafka

## Apache Kafka + Kafdrop + Docker Compose

Aqui trago um exemplo de como implementar um producer e um consumer do kafka em .NET 7;
Para montar nosso ambiente de desenvolvimento, deixo um arquivo docker-compose.yml  na raiz do projeto.

### Criando ambiente:
    Na raiz do projeto execute docker-compose up -d, o mesmo criara a network e os containers;
  
### Executando producer e consumer:
  #### Producer:
    Na raiz do projeto execute cd .\src\EnvioKafka\ assim você navega para o projeto producer. Então execute o seguinte comando: 
    dotnet run "localhost:9092" "topic-teste-kafdrop" "Mensagem 1" "Mensagem 2"
    
  #### Consumer
    Na raiz do projeto execute cd .\src\ConsumoKafka\ assim você navega para o projeto consumer. Então execute o seguinte comando: 
    dotnet run.
