## Why

Condomínios precisam de um sistema automatizado para calcular com precisão o valor que cada unidade deve pagar, considerando regras complexas de rateio de despesas e configurações variáveis. Hoje, esses cálculos são feitos manualmente ou com ferramentas inadequadas, causando erros e inconsistências.

## What Changes

- Sistema web completo para cálculo automático de condomínio com persistência em nuvem
- Suporte a regras configuráveis de despesas fixas e rateio
- Interface web para gerenciar apartamentos, despesas e regras de cálculo
- API backend para operações de cálculo e configuração
- Relatórios de valores por unidade

## Capabilities

### New Capabilities
- `gerenciamento-apartamentos`: Cadastro e manutenção de unidades (apartamentos) do condomínio
- `configuracao-despesas`: Definição de despesas e regras de cálculo (fixas, percentuais, por área, etc)
- `rateio-despesas`: Lógica de distribuição de despesas entre apartamentos conforme regras
- `calculo-condominio`: Engine central de cálculo do valor por unidade
- `relatorios-calculo`: Visualização e exportação de resultados de cálculos

### Modified Capabilities
<!-- Nenhuma capacidade existente sendo modificada nesta primeira fase -->

## Impact

- **Frontend**: Aplicação React para interface de usuário
- **Backend**: APIs .NET para lógica de negócio e cálculos
- **Database**: Schema PostgreSQL (Neon) para persistência de apartamentos, despesas, regras e resultados
- **Deployment**: Hospedagem em nuvem com acesso web
