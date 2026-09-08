---
name: create-migration
description: Criar uma nova migration no projeto
argument-hint: "[nome da migration] [nome do projeto]"
---

# Objetivo

- Atualiza EF Core mapping e gera migration coerente com o domínio.

# Quando utilizar

- Ao criar uma nova entidade no projeto, seja ela uma entidade de domínio ou um value object.

# Workflow

- Inspecione entidades e mappins atuais do projeto
- Instalar `dotnet-ef` global tool, caso não esteja instalado.
- Execute o comando `dotnet ef migrations add <NomeDaMigration>` para criar a migration.
- Execute o comando `dotnet ef database update` para aplicar a migration no banco de dados.

# Regras

- Pergunte explicitamente o nome da migration.
- Criar/a justar configurações EF Core.
- Identificar alteração do schema.

# Finalização

- Revise SQL/migrations para operações duvidosas
- Executar o comando `dotnet ef database update` para aplicar a migration no banco de dados.
- Execute o comando `dotnet build` para verificar se a solução foi criada corretamente.
- Execute o comando `dotnet test` para verificar se os testes estão passando.