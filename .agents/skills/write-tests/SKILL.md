---
name: write-tests
description: Criar testes unitários para projeto .NET 10
---

# Objetivo

- Criar testes unitários para projeto .NET 10, sequindo as diretrizes Clean Arquiteture e SOLID.

# Quando utilizar

- Ao iniciar a criação de testes unitários para um projeto .NET 10, após a criação da estrutura inicial do projeto.

# Workflow

- Entenda o objetivo do projeto e as regras de criação dos testes unitários.
- Verifique a estrutura do projeto e identifique os métodos e classes que precisam de testes unitários.
- Crie diretório /tests se ainda não existir.
- Crie projeto de testes unitários dentro de /tests.
- Crie testes unitários para os métodos e classes identificados, seguindo as boas práticas de testes unitários e as diretrizes Clean Arquiteture e SOLID.

# Regras

- Verifique se o projeto de testes unitários está referenciando corretamente os projetos da aplicação.
- Executar os testes unitários utilizando o comando `dotnet test` e verificar se todos os testes estão passando.
- Registrar falhas e erros encontrados durante a execução dos testes unitários e corrigi-los antes de prosseguir com o desenvolvimento do projeto.

# Finalização

- Execute o comando `dotnet build` para verificar se a solução foi criada corretamente.
- Execute o comando `dotnet test` para verificar se os testes unitários estão passando.