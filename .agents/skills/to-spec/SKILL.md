---
name: to-spec
description: Transforma requisitos informais de software em uma especificação técnica estruturada, testável e pronta para implementação.
argument-hint: "[requisito ou feature]"
---

# Objetivo
Transformar uma solicitação informal em uma especificação técnica executável.

# Entradas
- Requisito do usuário.
- Contexto já existente no repositório.
- Restrições arquiteturais encontradas no projeto.

# Workflow
1. Resuma o problema em até 3 frases.
2. Liste dúvidas somente se forem realmente bloqueadoras.
3. Identifique atores e casos de uso.
4. Defina requisitos funcionais.
5. Defina requisitos não funcionais.
6. Modele dados afetados.
7. Descreva contratos de API.
8. Liste edge cases.
9. Escreva critérios de aceitação verificáveis.
10. Escreva Definition of Done.
11. Salve a especificação em docs/specs quando houver acesso ao filesystem.

# Restrições
- Não invente regras de negócio sem marcá-las como hipótese.
- Critérios de aceitação devem ser testáveis.
- Prefira contratos explícitos a descrições vagas.
- Reutilize padrões existentes no repositório.

# Saída
1. Contexto
2. Objetivo
3. Escopo
4. Fora de escopo
5. Requisitos funcionais
6. Requisitos não funcionais
7. Modelo de dados
8. APIs
9. Edge cases
10. Critérios de aceitação
11. Definition of Done

# Verificação final
- Todo requisito importante possui critério de aceitação?
- Existem ambiguidades críticas não sinalizadas?
- A especificação pode ser implementada por outro desenvolvedor sem contexto oral adicional?