## ADDED Requirements

### Requirement: Cadastro de apartamentos
O sistema SHALL permitir cadastrar e manter informações de apartamentos/unidades do condomínio.

#### Scenario: Cadastrar novo apartamento
- **WHEN** usuário submete formulário com número, bloco, metragem, fração ideal, proprietário, dados de cobrança (detalhado a seguir) e se está ativo
- **THEN** apartamento é criado no banco e retorna ID único

##### Dados de cobrança
Os dados de cobrança referem-se ao contato que receberá o resultado calculado do condomínio. Deve conter:
- nome
- email
- telefone
- se é proprietário ou inquilino

#### Scenario: Validação de número duplicado
- **WHEN** usuário tenta cadastrar apartamento com número+bloco já existentes
- **THEN** sistema rejeita com erro "Unidade já existe"

#### Scenario: Atualizar dados do apartamento
- **WHEN** usuário edita metragem ou proprietário ou dados de cobrança de um apartamento existente
- **THEN** dados são atualizados e refletem em cálculos subsequentes

### Requirement: Listagem de apartamentos
O sistema SHALL retornar lista de todos os apartamentos cadastrados com suporte a filtros básicos.

#### Scenario: Listar todos os apartamentos
- **WHEN** usuário acessa endpoint GET /api/apartamentos
- **THEN** retorna array com todos os apartamentos (número, bloco, metragem, proprietário)

#### Scenario: Filtrar por bloco
- **WHEN** usuário faz GET /api/apartamentos?bloco=A
- **THEN** retorna apenas apartamentos do bloco A

### Requirement: Exclusão de apartamento
O sistema SHALL permitir remover apartamentos, mas não poderá remover se houver cálculos associados.

#### Scenario: Deletar apartamento sem cálculos
- **WHEN** usuário faz DELETE /api/apartamentos/{id} para unidade sem histórico
- **THEN** apartamento é removido com sucesso

#### Scenario: Rejeitar exclusão com cálculos vinculados
- **WHEN** usuário tenta deletar apartamento com cálculos no período atual
- **THEN** sistema retorna erro "Não é possível remover - existem cálculos associados"

### Requirement: Financeiro

#### Scenario: Cadastrar crédito
- **WHEN** usuário cadastra crédito para a unidade, com valor e justificativa
- **THEN** crédito é usado como desconto no condomínio calculado

#### Scenario: Cadastrar dívida
- **WHEN** usuário cadastra dívida para a unidade (juros, multa ou outras tarifas)
- **THEN** valor é acrescentado ao próximo condomínio