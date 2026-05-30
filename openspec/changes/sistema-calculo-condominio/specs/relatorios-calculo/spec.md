## ADDED Requirements

### Requirement: Visualizar resultado de cálculo
O sistema SHALL permitir consultar resultados de cálculos anteriores com filtragem.

#### Scenario: Recuperar cálculo por ID
- **WHEN** usuário acessa GET /api/calculos/{id}
- **THEN** retorna resultado completo: data, período, lista de valores por apartamento

#### Scenario: Listar cálculos de um período
- **WHEN** usuário faz GET /api/calculos?periodo=2024-05
- **THEN** retorna todos os cálculos do mês (pode haver múltiplos se recalculado)

### Requirement: Relatório por apartamento
O sistema SHALL gerar visualização de quanto cada unidade pagaria/pagou.

#### Scenario: Extrato de um apartamento
- **WHEN** usuário acessa dados de um apartamento específico
- **THEN** mostra histórico de valores pagos em últimos N períodos

### Requirement: Relatório consolidado do condomínio
O sistema SHALL gerar visão global dos valores totais e tendências.

#### Scenario: Resumo mensal
- **WHEN** usuário acessa relatório consolidado de um mês
- **THEN** mostra total arrecadado, valor médio por unidade, maior/menor valor

### Requirement: Exportar relatório
O sistema SHALL permitir baixar relatórios em formato padrão.

#### Scenario: Exportar para CSV
- **WHEN** usuário clica "Exportar" em um relatório
- **THEN** arquivo CSV é gerado com colunas: Apartamento, Metragem, Água, Luz, IPTU, ..., Total

#### Scenario: Exportar para PDF
- **WHEN** usuário clica "Exportar para PDF..." em um relatório
- **THEN** arquivo PDF separado por apartamento contendo memória de cálculo e valor devido pelo apartamento

#### Scenario: Exportar com timestamp
- **WHEN** relatório é exportado
- **THEN** nome do arquivo inclui data/hora (ex: relatorio_2024-05-15_1430.csv)

### Requirement: Comparação de cenários
O sistema SHALL permitir calcular "e se" alterarmos valores de despesa.

#### Scenario: Simulação de aumento de despesa
- **WHEN** usuário aumenta valor de Água em +20% para simular
- **THEN** sistema mostra novo valor por apartamento SEM salvar no banco

#### Scenario: Simulação não persiste
- **WHEN** usuário faz simulação e sai da tela
- **THEN** valores voltam ao normal (simulação descartada)

### Requirement: Histórico de alterações
O sistema SHALL manter log de quando cálculos foram recalculados.

#### Scenario: Ver quem recalculou
- **WHEN** usuário acessa detalhes de um cálculo
- **THEN** mostra data/hora do cálculo e (futuramente) quem o executou

#### Scenario: Indicar versão de regras usada
- **WHEN** cálculo foi executado com regras diferentes de agora
- **THEN** relatório avisa "Nota: Realizado com versão anterior de regras"
