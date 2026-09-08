---
name: create-pr
description: Criar Pull Request no GitHub
---

# Objetivo

- Criar Pull Request no GitHub para o projeto atual.

# Quando utilizar

- Ao finalizar uma feature, correção de bug ou melhoria no projeto atual.

# Workflow

- Verifique as mudanças realizadas no projeto e se elas estão de acordo com as regras de desenvolvimento.
- Crie uma branch com o nome da feature, seguindo o seguinte padrão: `feature/<nome-da-feature>`, ` /<nome-do-bug>`, `hotfix/<nome-do-hotfix>`.
- Faça commit das mudanças realizadas no projeto, seguindo o seguinte padrão: `feat: <descrição-da-feature>`, `fix: <descrição-do-bug>`, `hotfix: <descrição-do-hotfix>`, `fix: <descrição-do-refactor>`, `docs: <descrição-da-documentação>`, `test: <descrição-do-teste>`.
- Crie apenas uma primeira vez o seguinte template de Pull Request no GitHub, seguindo o seguinte padrão:

```
## Contexto
...

## O que foi alterado
- ...

## Decisões técnicas
- ...

## Como validar
1. ...

## Testes executados
- [ ] dotnet build
- [ ] dotnet test
- [ ] docker compose up --build

## Riscos
- ...

## Evidências / observações
...
``` 

# Regras

- Aplique o template de Pull Request no GitHub para todas as Pull Requests criadas corretamente.

# Finalização

- Crie a Pull Request no GitHub, aplicando o template definido.
- Certifique-se das regras de nome de branch e commit, seguindo o padrão definido.