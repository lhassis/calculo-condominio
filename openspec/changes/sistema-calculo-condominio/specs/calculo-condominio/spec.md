## ADDED Requirements

### Requirement: Engine de cálculo de condomínio
O sistema SHALL calcular o valor total que cada apartamento deve pagar em um período.

#### Scenario: Calcular condomínio para um período
- **WHEN** usuário executa POST /api/calculo com período "2024-05"
- **THEN** sistema calcula valores para TODOS os apartamentos e retorna resultado

#### Scenario: Valor zero para apartamento desativado
- **WHEN** apartamento está marcado como inativo
- **THEN** não é incluído no cálculo do período

### Requirement: Orquestração de regras de rateio
O sistema SHALL aplicar todas as regras configuradas na ordem correta e somar os resultados.

#### Scenario: Aplicar múltiplas despesas com regras diferentes
- **WHEN** cálculo inclui: Água (fração ideal), Luz área comum (fração ideal), Despesas com limpeza (fração ideal), IPTU (igualitário), Taxa (percentual)
- **THEN** valores de cada regra são calculados independentemente e somados

#### Scenario: Respeitar desativações temporárias
- **WHEN** despesa está desativada no período do cálculo
- **THEN** não é incluída no resultado

### Requirement: Arredondar valores corretamente
O sistema SHALL garantir que a soma de todos os valores rateados é igual ao valor total da despesa (sem perdas por arredondamento).

#### Scenario: Distribuir sem perder centavos
- **WHEN** despesa R$ 1000,01 é dividida entre 3 apartamentos
- **THEN** total de A1 + A2 + A3 = R$ 1000,01 exatamente

#### Scenario: Ajuste do último item
- **WHEN** divisão resulta em resto de centavos
- **THEN** último apartamento recebe o ajuste (rounding)

### Requirement: Persistir resultado do cálculo
O sistema SHALL armazenar resultado de cada cálculo para auditoria e comparações futuras.

#### Scenario: Resultado retorna ID de cálculo
- **WHEN** cálculo é executado
- **THEN** retorna ID único (UUID) e permite recuperar resultado depois

#### Scenario: Não permitir recalcular período duplicado sem confirmação
- **WHEN** usuário tenta calcular período já calculado
- **THEN** sistema avisa que substituirá resultado anterior

### Requirement: Validação de dados antes de calcular
O sistema SHALL verificar integridade de dados antes de executar cálculo.

#### Scenario: Erro se nenhum apartamento cadastrado
- **WHEN** usuário tenta calcular com zero apartamentos
- **THEN** sistema retorna erro "Nenhuma unidade para calcular"

#### Scenario: Erro se nenhuma despesa configurada
- **WHEN** usuário tenta calcular sem despesas no período
- **THEN** sistema retorna erro "Nenhuma despesa configurada para o período"

#### Scenario: Erro se metragem total é zero
- **WHEN** apartamentos têm metragem zerada e há despesa por metragem
- **THEN** sistema retorna erro "Metragem total insuficiente para rateio"

### Requirement: Relatório detalhado do cálculo
O sistema SHALL retornar breakdown completo de como cada valor foi calculado.

#### Scenario: Detalhe por despesa e apartamento
- **WHEN** usuário executa cálculo
- **THEN** retorna para cada apartamento: valor total, despesa1=X, despesa2=Y, etc

#### Scenario: Agrupamento de despesas por tipo
- **WHEN**: resultado do cálculo é solicitado
- **THEN**: retorna as depesas agrupadas por seu tipo: por fração ideal, por percentual, valor fixo

#### Scenario: Incluir justificativa de cada cálculo
- **WHEN** apartamento tem isenção ou acréscimo
- **THEN** resultado mostra "valor_base: R$1000, isenção (-50%): -R$500, total: R$500"

### Requirement: Envio de cálculo
- **WHEN** cálculo já está feito e persistido, usuário pode solicitar envio do resultado para os responsáveis de cada unidade
- **THEN** relatório em pdf é enviado para o e-mail cadastrado nos "Dados de cobrança" do apartamento contendo memória de cálculo e valor cobrado para aquela unidade
