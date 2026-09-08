---
name: create-entity
description: Criar uma nova entidade no projeto
argument-hint: "[nome da entidade] [nome do projeto]"
---

# Objetivo

- Cria entidade/value objects respeitando invariantes e padrões do projeto.

# Quando utilizar

- Ao criar uma nova entidade no projeto, seja ela uma entidade de domínio ou um value object.

# Workflow

- Adicione `Microsoft.EntityFrameworkCore` ao projeto.
- Adicione `Microsoft.EntityFrameworkCore.Design` ao projeto.
- Adicione `Pomelo.EntityFrameworkCore.MySql` ao projeto.
- Crie um arquivo com as variáveis de ambiente do banco de dados, como `DB_HOST`, `DB_PORT`, `DB_USER`, `DB_PASSWORD` e `DB_NAME`.
- Aplique as variávies de ambiente ao `ConnectionStrings__DefaultConnection`


# Regras

- Crie arquivos locais para armazenamento das variáveis de ambiente. Ex: `.env`, `.env.local`, `.env.development`, `.env.production`.
- Não versionar arquivos de variáveis de ambiente, como `.env`, `.env.local`, `.env.development`, `.env.production`.
- 

# Finalização

- Ao final do processo, o usuário deve ter uma nova entidade/value object criada no projeto, respeitando as invariantes e padrões do projeto.
- Execute o comando `dotnet build` para verificar se a solução foi criada corretamente.