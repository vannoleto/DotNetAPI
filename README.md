# Minha API

Este projeto é uma API desenvolvida em .NET, seguindo os princípios de orientação a objetos e utilizando o padrão Repository com Entity Framework. A API é estruturada para facilitar a manutenção e a escalabilidade.

## Estrutura do Projeto

- **MinhaApi**: Contém a implementação da API.
  - **Controllers**: Controladores que gerenciam as requisições HTTP.
  - **Models**: Modelos que representam a estrutura dos dados.
  - **Repositories**: Implementação do padrão Repository para acesso a dados.
  - **Services**: Lógica de negócios da aplicação.
  - **Program.cs**: Ponto de entrada da aplicação.
  - **Startup.cs**: Configuração dos serviços e middleware.
  - **appsettings.json**: Configurações da aplicação.

- **MinhaApi.Testes**: Contém os testes unitários da API.
  - **Controllers**: Testes para os controladores.
  - **Repositories**: Testes para os repositórios.
  - **Services**: Testes para os serviços.
  - **appsettings.json**: Configurações específicas para os testes.

## Instalação

1. Clone o repositório.
2. Navegue até a pasta do projeto.
3. Execute o comando `dotnet restore` para restaurar as dependências.
4. Execute o comando `dotnet run` para iniciar a API.

## Uso

A API pode ser acessada através do endpoint base. Utilize ferramentas como Postman ou cURL para fazer requisições HTTP aos controladores disponíveis.

## Testes

Os testes podem ser executados utilizando o comando `dotnet test` na pasta de testes. Certifique-se de que o ambiente de teste está configurado corretamente no arquivo `appsettings.json` dos testes.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.