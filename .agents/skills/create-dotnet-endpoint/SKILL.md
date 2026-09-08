---
name: create-dotnet-endpoint
description: Criar endpoint para projeto .NET 10
argument-hint: "[nome do endpoint]"
---

# Objetivo

- Criar endpoint para projeto .NET 10, seguindo as diretrizes Clean Arquiteture e SOLID, dentro das estrutura de API.

# Quando utilizar

- Ao criar um novo endpoint no projeto, seja ele para uma entidade de domínio ou um value object.

# Workflow

- Entenda o objetivo do endpoint e as regras de criação do mesmo.
- Verifique arquitetura existentes
- Criar diretório /src/Api/Endpoints/<NomeDoEndpoint>
- Criar arquivo <NomeDoEndpoint>Endpoint.cs com a implementação do endpoint.
- Criar ou atualizar arquivo <NomeDoEndpoint>Response.Http para definir o contrato de resposta

# Regras

- Pergunte explicitamente o nome do endpoint.
- Crie o endpoint seguindo as diretrizes Clean Arquiteture e SOLID, coerentes com o projeto existente.


# Finalização

- Execute o comando `dotnet build` para verificar se a solução foi criada corretamente.
- Execute o comando `dotnet test` para verificar se os testes estão passando.
- Execute o comando `dotnet run` para verificar se o endpoint está funcionando corretamente.
- Certifique-se de que o endpoint está seguindo as diretrizes Clean Arquiteture e SOLID, coerentes com o projeto existente.
- Adicione o endpoint ao swagger para que ele seja documentado e testado.