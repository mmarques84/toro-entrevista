# Sistema de Orquestração de Cálculos Financeiros com RabbitMQ

## Estrutura do Projeto

- **Business**: Contém a lógica de negócios, incluindo a classe `OrquestradorDeCalculo`.
- **Domain**: Contém as classes de domínio, como `PosicaoConsolidada` e `Custodia`.
- **Messaging**: Contém a implementação do serviço RabbitMQ, `RabbitMQService`.
- **Repository**: Contém a implementação do repositório, como `CustodiaRepo`.
- **Console**: Contém o ponto de entrada do aplicativo, `Program.cs`.

## Requisitos

- **.NET Framework 4.7.2**
- **RabbitMQ**
- **Pacotes NuGet**:
  - `RabbitMQ.Client`
  - `Newtonsoft.Json`

## Configuração

### 1. Instalar RabbitMQ
Siga as instruções de instalação no site oficial do RabbitMQ:

[https://www.rabbitmq.com/download.html](https://www.rabbitmq.com/download.html)

### 2. Configurar RabbitMQ
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

- Certifique-se de que o RabbitMQ está em execução e acessível no localhost na porta 5672.
- As credenciais padrão são:
  - **Usuário**: guest
  - **Senha**: guest

### 3. Instalar Pacotes NuGet
1. No Visual Studio, clique com o botão direito no projeto e selecione **"Gerenciar Pacotes NuGet"**.
2. Procure e instale os pacotes `RabbitMQ.Client` e `Newtonsoft.Json`.

## Como Executar

1. Abra o projeto no Visual Studio.
2. Verifique se o RabbitMQ está rodando localmente.
3. Compile e execute o projeto. O sistema começará a realizar os cálculos financeiros e enviará notificações via RabbitMQ.

## Contribuições

Se você deseja contribuir para o projeto, fique à vontade para fazer um fork e enviar pull requests com melhorias ou correções.

# Construa a imagem Docker
docker-compose build
# Inicie os contêineres
docker-compose up
