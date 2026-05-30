## ADDED Requirements

### Requirement: Configuração de tipos de despesa
O sistema SHALL permitir definir tipos de despesas (água, luz, IPTU, etc) e suas regras de rateio.

#### Scenario: Criar tipo de despesa com regra por m²
- **WHEN** usuário cria despesa "Água" com regra "rateio_por_metragem"
- **THEN** sistema armazena tipo e regra, pronto para ser usada em cálculos

#### Scenario: Validação de regra inválida
- **WHEN** usuário tenta criar despesa com regra não suportada
- **THEN** sistema retorna erro "Regra de rateio inválida"

#### Scenario: Editar regra de despesa
- **WHEN** usuário altera regra de "rateio_por_metragem" para "rateio_percentual_fixo"
- **THEN** mudança é registrada (com versionamento para cálculos históricos)

### Requirement: Configuração de despesas fixas
O sistema SHALL permitir configurar despesas fixas (valores mensais/anuais recorrentes).

#### Scenario: Criar despesa fixa mensal
- **WHEN** usuário cria despesa fixa "IPTU" com valor R$ 10.000 e período "mensal"
- **THEN** sistema armazena e será incluída em cada cálculo do período

#### Scenario: Despesa fixa com data de início e fim
- **WHEN** usuário cria despesa fixa válida apenas de jan a junho
- **THEN** sistema respeita intervalo e não inclui em períodos fora do range

### Requirement: Configuração de parâmetros de rateio
O sistema SHALL permitir definir parâmetros para cada tipo de regra (ex: percentual para fixo).

#### Scenario: Parâmetro percentual fixo
- **WHEN** usuário configura despesa com regra "percentual_fixo" e valor 30%
- **THEN** 30% do total é rateado igualmente entre todos os apartamentos

#### Scenario: Parâmetro por unidade
- **WHEN** usuário configura despesa com regra "por_unidade"
- **THEN** valor total é dividido pelo número de unidades (rateio igualitário)

### Requirement: Listar configurações de despesa
O sistema SHALL retornar todas as despesas e regras configuradas.

#### Scenario: Listar tipos de despesa
- **WHEN** usuário acessa GET /api/despesas
- **THEN** retorna lista com tipo, regra, parâmetros e status (ativo/inativo)

#### Scenario: Desativar despesa sem deletar
- **WHEN** usuário desativa uma despesa sem deletar
- **THEN** despesa não aparece em novos cálculos mas histórico é preservado
