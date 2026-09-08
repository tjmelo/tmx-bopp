---
name: create-dotnet-boilerplate
description: Criar estrutura inicial para projeto .NET 10
argument-hint: "[nome do projeto] [nome da solução]"
---

# Objetivo

- Criar estrutura inicial para projeto .NET 10, sequindo as diretrizes Clean Arquiteture e SOLID.
- Criar diretório para testes unitários
- Preservar as camadas da aplicação: API, Domain, Infraestructure, Application, dentro de um diretório /src

# Quando utilizar

- Ao iniciar um novo projeto .NET

# Workflow

- Entenda o objetivo do projeto e as regras de criação da estrutura.
- Verifique arquitetura existentes
- Criar diretório /src
- Criar diretório /tests
- Criar projeto API dentro de /src
- Criar projeto Domain dentro de /src
- Criar projeto Infraestructure dentro de /src
- Criar projeto Application dentro de /src

# Regras

- Pergute explicitamente o nome do projeto e o nome da solução.
- Não crie nehum arquivo de código, apenas a estrutura de diretórios e arquivos de configuração.
- Não exponha informações sensíveis do projeto.
- Para /src/<Nome do projeto>.API, utilize o template webapi do .NET com use controllers e configure para utilizar o Swagger.
- Criar arquivo .gitignore com as regras padrões para projetos .NET
- Criar arquivo .editorconfig com as regras padrões para projetos .NET
- Criar arquivo global.json com a versão do SDK .NET 10
- Criar arquivo .sln com o nome da solução

# Finalização

Ao final do processo, o usuário deve ter uma estrutura de diretórios e arquivos de configuração para iniciar um projeto .NET 10, seguindo as diretrizes Clean Arquiteture e SOLID.

- Execute o comando `dotnet buid` para verificar se a solução foi criada corretamente.
- Execute o comando `dotnet test` para verificar se os testes unitários foram criados corretamente.
- Verifique warnings e erros no console e corrija-os antes de prosseguir com o desenvolvimento do projeto.
- Verifique a formatação do código e corrija-a antes de prosseguir com o desenvolvimento do projeto.
- Crie ou atualize as specs em /docs/specs para documentar a estrutura do projeto e as regras de criação da estrutura.