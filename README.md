# FiapCloudGames Catalog API

API construída em **.NET 8** para gerenciamento de jogos e biblioteca de jogos.

**Obs**: Explicação de Infra em https://github.com/joseeduardoleite/fcg-orchestration

## 📦 Tecnologias & Ferramentas

- .NET 8
- C#
- ASP.NET Core Web API
- MassTransit
- RabbitMQ
- Docker
- Kubernetes
- FluentValidation
- AutoMapper
- Moq + xUnit (para testes unitários)
- Asp.Versioning (API versioning)

## 🚀 Funcionalidades

- CRUD de jogos
- Validação de DTOs usando FluentValidation
- Controle de acesso via claims e roles (`Admin`, `Usuario`)
- API versioning


## 🐳 Docker

Esta API possui suporte a containerização via Docker.

### Build da imagem

Na raiz do projeto:

```bash
docker build -t fcg-catalog-api .
```
Se quiser, pode executar o container localmente
```bash
docker run -d -p 5001:80 --name fcg-catalog-api fcg-catalog-api
```
A API ficará disponível em http://localhost:5001/swagger

## ☸ Kubernetes

Esta API faz parte da arquitetura de microserviços do projeto FiapCloudGames - 2 fase.

Orquestrada com Kubernetes e comunicação assíncrona via RabbitMQ.

Os manifests desta API estão localizados na pasta:
```bash
/k8s
```
Para realizar o deploy individual desta API no cluster:
```bash
kubectl apply -f k8s/
```

## 🔧 Setup

1. Clone o repositório:

```bash
git clone https://github.com/joseeduardoleite/fcg-catalog-api.git
```

2. Restaure os pacotes:
```bash
dotnet restore
```

3. Build do projeto:
```bash
dotnet build
```

## 🏃‍♂️ Executar a API
```bash
dotnet run --project FiapCloudGames.Catalog.Api
```
-> Os testes incluem validação de DTOs usando FluentValidation, mocks de serviços e controllers.

## Atenção
- Deve ser realizado login através da rota de login, com o usuario sugerido, que é o admin.
- Após login, pegar o token gerado e colocar no authorize pelo swagger.

## 🔄 Mapping (AutoMapper)

- AutoMapper é usado para converter entre Entities e DTOs.

- Perfis são carregados automaticamente via DI.

## 👮 Controle de acesso

- Role `Admin`: acesso total a todos os endpoints.

- Role `Usuario`: acesso restrito (ex.: apenas ao próprio recurso).

- Métodos que requerem admin possuem `[Authorize(Roles = "Admin")]`.

## 📝 Endpoints

## Jogos

### GET
`/v1/jogos`

- Retorna todos os jogos

### GET
`/v1/jogos/{id}`

- Retorna um jogo específico

### GET
`/v1/jogos/{nome}`

- Retorna um jogo por nome parcial

### GET
`/v1/jogos/{anoLancamento:int}`

- Retorna jogos lançados em um ano específico

### POST
`/v1/jogos`

- Admin apenas

- Cria um jogo

### Request:
```json
{
  "nome": "Jogo X",
  "lancamento": "2025-05-01T00:00:00Z",
  "preco": 199.9
}
```

### Response 201 Created:
```json
{
  "id": "d4e5f6a7-8b9c-4d0e-9f2f-123456789abc",
  "nome": "Jogo X",
  "lancamento": "2025-05-01T00:00:00Z",
  "preco": 199.9
}
```