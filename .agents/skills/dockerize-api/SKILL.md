---
name: dockerize-api
description: Criar processo de containerização para projeto .NET 10
---

# Objetivo

- Criar processo de containerização para projeto .NET 10, com dockerfile e docker-compose.yml.

# Quando utilizar

- Ao iniciar a containerização de um projeto .NET 10.

# Workflow

- Entenda o objetivo do projeto e as regras de criação do processo de containerização.
- Verifique a estrutura do projeto e identifique os serviços que precisam ser containerizados.
- Crie um arquivo Dockerfile na raiz do projeto, seguindo as boas práticas de containerização
- Crie um arquivo docker-compose.yml na raiz do projeto, definindo os serviços e suas dependências, seguindo as boas práticas de containerização.
- Configure as variáveis de ambiente necessárias para a execução dos serviços, e conexão com a base de dados, seguindo as boas práticas de containerização.
- Configure os volumes e redes necessárias para a execução dos serviços, seguindo as boas práticas de containerização.
- Configure os comandos de inicialização dos serviços, seguindo as boas práticas de containerização.
- Configure os healthchecks dos serviços, seguindo as boas práticas de containerização.
- Configure os logs dos serviços, seguindo as boas práticas de containerização.
- Configure os testes de integração dos serviços, seguindo as boas práticas de containerização.

# Regras

- Não exponha informações sensíveis do projeto.
- Verifique se os serviços estão sendo executados corretamente utilizando o comando `docker-compose up` e verificar se todos os serviços - API e MySQL estão funcionando corretamente.
- Registrar falhas e erros encontrados durante a execução dos serviços e corrigi-los antes de prosseguir com o desenvolvimento do projeto.

# Finalização

- Execute o comando `docker-compose up` para verificar se os serviços estão sendo executados corretamente.
- Execute o comando `docker-compose down` para parar os serviços e liberar os recursos utilizados.