# Estrutura do Projeto ShoppingList

## Visão Geral

Projeto .NET 10 seguindo as diretrizes de Clean Architecture e SOLID.

## Estrutura de Diretórios

```
/
├── src/
│   ├── ShoppingList.API/          # Camada de apresentação (ASP.NET Core)
│   ├── ShoppingList.Application/  # Casos de uso / regras de aplicação
│   ├── ShoppingList.Domain/       # Entidades e regras de negócio
│   └── ShoppingList.Infrastructure/ # Persistência e recursos externos
├── tests/
│   └── ShoppingList.UnitTests/    # Testes unitários (xUnit)
├── docs/
│   └── specs/                     # Especificações do projeto
├── .editorconfig                  # Regras de formatação
├── .gitignore                     # Regras de ignore do git
├── global.json                    # Versão do SDK (.NET 10)
└── ShoppingList.slnx              # Solução (formato .NET 10)
```

## Dependências entre Camadas

- `ShoppingList.API` → `ShoppingList.Application`, `ShoppingList.Infrastructure`
- `ShoppingList.Application` → `ShoppingList.Domain`
- `ShoppingList.Infrastructure` → `ShoppingList.Application`
- `ShoppingList.UnitTests` → `ShoppingList.Application`, `ShoppingList.Infrastructure`
- `ShoppingList.Domain` → (sem dependências)

## Regras de Criação da Estrutura

1. Usar Clean Architecture: dependências sempre apontam para o núcleo (`Domain`).
2. Seguir SOLID: responsabilidades bem definidas por camada.
3. Nome da solução e dos projetos: prefixo `ShoppingList`.
4. Testes unitários ficam em `/tests` e referenciam as camadas que testam.
5. Não expor informações sensíveis em arquivos de configuração.