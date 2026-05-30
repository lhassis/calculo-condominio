## ADDED Requirements

### Requirement: Rateio por metragem
O sistema SHALL distribuir despesa proporcionalmente à área de cada apartamento.

#### Scenario: Calcular rateio por m² com proporção simples
- **WHEN** despesa "Água" (regra metragem) com total R$ 1000, apartamentos: A1=50m², A2=100m²
- **THEN** A1 paga R$ 333,33 e A2 paga R$ 666,67 (proporção 1:2)

#### Scenario: Rateio com múltiplos apartamentos
- **WHEN** despesa R$ 6000 entre 6 apartamentos de 100m² cada
- **THEN** cada apartamento paga R$ 1000

### Requirement: Rateio igualitário (por unidade)
O sistema SHALL distribuir despesa igualmente entre todos os apartamentos.

#### Scenario: Dividir despesa entre 10 apartamentos
- **WHEN** despesa "Condominium Geral" (regra por_unidade) com total R$ 2000, 10 unidades
- **THEN** cada unidade paga R$ 200

#### Scenario: Rateio com resto
- **WHEN** despesa R$ 1000 dividida entre 3 apartamentos (não divisível)
- **THEN** distribuição: A1=R$ 333,33, A2=R$ 333,33, A3=R$ 333,34 (centavos ajustados)

### Requirement: Rateio por percentual fixo
O sistema SHALL distribuir um percentual da despesa total igualmente.

#### Scenario: 50% do valor total distribuído
- **WHEN** despesa com regra percentual_fixo=50%, valor total R$ 1000
- **THEN** apenas R$ 500 é rateado (resto pode ser rateado por outra regra)

### Requirement: Validações de integridade
O sistema SHALL validar que rateios resultam em 100% da despesa e detectar inconsistências.

#### Scenario: Erro se rateio não fecha em 100%
- **WHEN** regras configuradas resultam em 99% da despesa
- **THEN** sistema retorna erro "Rateio incompleto"

#### Scenario: Detectar divisão por zero
- **WHEN** tentar rateio por metragem em condomínio com 0 apartamentos
- **THEN** sistema retorna erro "Nenhuma unidade para ratear"

### Requirement: Aplicar desconto/acréscimo individual
O sistema SHALL permitir ajustes per-apartamento (isenções, acréscimos especiais).

#### Scenario: Isenção parcial
- **WHEN** apartamento A1 recebe 50% de isenção em "Taxa de Água"
- **THEN** valor calculado para A1 é reduzido em 50%

#### Scenario: Desconto por crédito prévio
- **WHEN** apartamento possui crédito prévio
- **THEN** condomínio calculado é descontado no valor do crédito (evitando condomínio menor que 0).