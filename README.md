# ShoppingList

Aplicação de gerenciamento de **listas de compras**, desenvolvida em **.NET 10** seguindo os princípios de **Clean Architecture** e **SOLID**.

> Status: estrutura inicial (boilerplate). Regras de negócio e funcionalidades serão adicionadas nas próximas etapas.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![Clearn Architecture](https://img.shields.io/badge/Architecture-Clean%20%26%20SOLID-blueviolet?style=flat-square)
![Build](https://img.shields.io/badge/build-passing-brightgreen?style=flat-square)
![Testes](https://img.shields.io/badge/tests-passing-brightgreen?style=flat-square)
![Cobertura](https://img.shields.io/badge/coverage-TBD-yellow?style=flat-square)
![Linguagem](https://img.shields.io/badge/lang-C%23-239120?style=flat-square&logo=csharp)

## Índice

- [Objetivo](#objetivo)
- [Tecnologias](#tecnologias)
- [Arquitetura](#arquitetura)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Regras do Projeto](#regras-do-projeto)
- [Workflow](#workflow)
- [Como Executar](#como-executar)
- [Como Rodar os Testes](#como-rodar-os-testes)
- [Como Contribuir](#como-contribuir)
- [Reportar Bugs e Solicitar Funcionalidades](#reportar-bugs-e-solicitar-funcionalidades)
- [Licença](#licença)

## Objetivo

O projeto `ShoppingList` tem como objetivo fornecer uma aplicação para criação e gerenciamento de listas de compras, permitindo aos usuários organizar seus itens de forma simples e eficiente.

A base inicial entrega a infraestrutura necessária para o desenvolvimento seguro e testável do domínio, com camadas bem definidas e independentes.

## Tecnologias

| Tecnologia | Versão |
| --- | --- |
| .NET | 10.0 |
| ASP.NET Core | 10.0 |
| xUnit | via `dotnet new xunit` |
| C# | 13 (padrão do SDK 10) |

## Arquitetura

O projeto segue os princípios de **Clean Architecture** e **SOLID**:

- Dependências sempre apontam para o núcleo (`Domain`).
- Cada camada possui responsabilidade única e bem definida.
- Testes isolam as camadas para validar comportamento sem acoplamento.

### Diagrama de Arquitetura

- [Diagrama draw.io](docs/diagrams/architecture.drawio) — abra em [app.diagrams.net](https://app.diagrams.net) ou no editor de sua preferência.

> **Depêndencias entre camadas (Compatibilidade):**
> `API → Application, Infrastructure` · `Application → Domain` · `Infrastructure → Application` · `Domain → (nenhuma)`

## Estrutura do Projeto

```
/
├── src/
│   ├── ShoppingList.API/            # Apresentação (ASP.NET Core) — controllers/endpoints
│   ├── ShoppingList.Application/    # Casos de uso — handlers, serviços de aplicação
│   ├── ShoppingList.Domain/         # Entidades e regras de negócio
│   └── ShoppingList.Infrastructure/ # Persistência e recursos externos
├── tests/
│   └── ShoppingList.UnitTests/      # Testes unitários (xUnit)
├── docs/
│   ├── diagrams/                    # Diagramas (draw.io)
│   └── specs/                       # Especificações do projeto
├── .editorconfig                    # Regras de formatação de código
├── .gitignore                       # Arquivos ignorados pelo git
├── global.json                      # Versão do SDK do .NET
└── ShoppingList.slnx                # Solução (formato .slnx)
```

Especificação detalhada: [`docs/specs/estrutura-do-projeto.md`](docs/specs/estrutura-do-projeto.md).

## Regras do Projeto

1. **Clean Architecture:** dependências sempre apontam para o núcleo (`Domain`).
2. **SOLID:** cada camada tem uma única responsabilidade; componentes são abertos para extensão e fechados para modificação.
3. **Nomenclatura:** prefixo `ShoppingList` para solução e projetos.
4. **Testes:** testes unitários ficam em `/tests` e referenciam as camadas que validam.
5. **Configuração:** não expor informações sensíveis (senhas, chaves de API, connection strings) em arquivos versionados.
6. **Formatação:** seguir o `.editorconfig` e as convenções de código do projeto.
7. **Nenhuma dependência para o `Domain`:** a camada de domínio deve permanecer independente de infraestrutura e frameworks.

## Workflow

1. **Especificação:** requisitos são documentados em `docs/specs/` antes da implementação.
2. **Desenvolvimento:** implementação nas camadas seguindo Clean Architecture (Domain → Application → Infrastructure → API).
3. **Testes:** adicionar testes unitários para novos comportamentos.
4. **Verificação:** executar `dotnet build` e `dotnet test`, corrigindo warnings, erros e formatação.
5. **Documentação:** atualizar `docs/` e `README.md` sempre que a estrutura ou regras mudarem.

## Como Executar

Pré-requisitos:

- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (o `global.json` fixa a versão).

Passos:

```bash
# Restaurar dependências
dotnet restore

# Executar a API em modo de desenvolvimento
dotnet run --project src/ShoppingList.API
```

A API estará disponível em `http://localhost:5000` (ajuste conforme o `launchSettings.json`).

## Como Rodar os Testes

```bash
# Executar todos os testes da solução
dotnet test

# Executar com relatório detalhado
dotnet test --logger "console;verbosity=detailed"
```

## Como Contribuir

1. Faça um *fork* do repositório e crie uma branch a partir de `main`:

   ```bash
   git checkout -b feature/nome-da-feature
   ```

2. Implemente a mudança respeitando as [regras do projeto](#regras-do-projeto).
3. Adicione testes unitários para os novos comportamentos.
4. Execute `dotnet build` e `dotnet test` e certifique-se de que não há warnings ou erros.
5. Abra um *Pull Request* descrevendo a mudança e as evidências de verificação.

## Reportar Bugs e Solicitar Funcionalidades

- **Bugs:** abra uma *issue* descrevendo o comportamento esperado, o comportamento observado, os passos para reproduzir e o ambiente (SO, versão do SDK, etc.).
- **Funcionalidades:** abra uma *issue* ou *discussion* descrevendo o cenário de uso, o benefício esperado e sugestões de implementação.

Antes de abrir, verifique se já não existe uma *issue* relacionada.

## Licença

Este projeto ainda não possui licença definida.