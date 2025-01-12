# Sistema de Orquestra��o de C�lculos Financeiros com RabbitMQ

## Estrutura do Projeto

- **Business**: Cont�m a l�gica de neg�cios, incluindo a classe `OrquestradorDeCalculo`.
- **Domain**: Cont�m as classes de dom�nio, como `PosicaoConsolidada` e `Custodia`.
- **Messaging**: Cont�m a implementa��o do servi�o RabbitMQ, `RabbitMQService`.
- **Repository**: Cont�m a implementa��o do reposit�rio, como `CustodiaRepo`.
- **Console**: Cont�m o ponto de entrada do aplicativo, `Program.cs`.

## Requisitos

- **.NET Framework 4.7.2**
- **RabbitMQ**
- **Pacotes NuGet**:
  - `RabbitMQ.Client`
  - `Newtonsoft.Json`

## Configura��o

### 1. Instalar RabbitMQ
Siga as instru��es de instala��o no site oficial do RabbitMQ:

[https://www.rabbitmq.com/download.html](https://www.rabbitmq.com/download.html)

### 2. Configurar RabbitMQ
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

- Certifique-se de que o RabbitMQ est� em execu��o e acess�vel no localhost na porta 5672.
- As credenciais padr�o s�o:
  - **Usu�rio**: guest
  - **Senha**: guest

### 3. Instalar Pacotes NuGet
1. No Visual Studio, clique com o bot�o direito no projeto e selecione **"Gerenciar Pacotes NuGet"**.
2. Procure e instale os pacotes `RabbitMQ.Client` e `Newtonsoft.Json`.

## Como Executar

1. Abra o projeto no Visual Studio.
2. Verifique se o RabbitMQ est� rodando localmente.
3. Compile e execute o projeto. O sistema come�ar� a realizar os c�lculos financeiros e enviar� notifica��es via RabbitMQ.

## Contribui��es

Se voc� deseja contribuir para o projeto, fique � vontade para fazer um fork e enviar pull requests com melhorias ou corre��es.

# Construa a imagem Docker
docker-compose build
# Inicie os cont�ineres
docker-compose up
