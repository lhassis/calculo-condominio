## 1. Setup de Infraestrutura

- [ ] 1.1 Provisionar PostgreSQL em Neon e obter connection string
 - [x] 1.1 Provisionar PostgreSQL em Neon e obter connection string
 - [x] 1.2 Criar repositório backend .NET (ASP.NET Core 8.0)
 - [x] 1.3 Criar repositório frontend React com Vite (TypeScript)
 - [x] 1.4 Configurar CI/CD pipeline básico (GitHub Actions)

## 2. Backend .NET - Configuração Inicial

- [ ] 2.1 Estruturar pastas do backend (Models, Services, Controllers, Repositories, DTOs, Migrations)
- [ ] 2.2 Instalar NuGet packages (EF Core, Npgsql, AutoMapper, FluentValidation, MailKit)
- [ ] 2.3 Configurar DbContext com EF Core
- [ ] 2.4 Configurar connection string (Neon PostgreSQL)
- [ ] 2.5 Configurar AutoMapper
- [ ] 2.6 Configurar Swagger/OpenAPI

## 3. Banco de Dados - Migrations

- [ ] 3.1 Criar migration: tabelas base (apartamentos, dados_cobranca, creditos)
- [ ] 3.2 Criar migration: tabelas de despesas (despesas, parametros_despesa)
- [ ] 3.3 Criar migration: tabelas de cálculo (calculos, resultados_calculo)
- [ ] 3.4 Criar migration: tabelas de ajustes e envios (ajustes_apartamento, envios_email)
- [ ] 3.5 Adicionar índices em chaves estrangeiras e campos de busca
- [ ] 3.6 Executar migrations no banco

## 4. Backend .NET - Modelos (Entities)

- [ ] 4.1 Implementar Apartamento entity
- [ ] 4.2 Implementar DadosCobranca entity
- [ ] 4.3 Implementar Credito entity
- [ ] 4.4 Implementar Despesa e ParametroDespesa entities
- [ ] 4.5 Implementar Calculo e ResultadoCalculo entities
- [ ] 4.6 Implementar AjusteApartamento entity
- [ ] 4.7 Implementar EnvioEmail entity

## 5. Backend .NET - Repositórios

- [ ] 5.1 Criar IRepository<T> genérico
- [ ] 5.2 Implementar Repository<T> genérico
- [ ] 5.3 Criar interfaces específicas (IApartamentoRepository, IDespesaRepository, etc)
- [ ] 5.4 Implementar repositórios específicos com lógica customizada

## 6. Backend .NET - DTOs

- [ ] 6.1 Criar DTOs de Apartamento (Create, Update, Response)
- [ ] 6.2 Criar DTOs de DadosCobranca
- [ ] 6.3 Criar DTOs de Credito
- [ ] 6.4 Criar DTOs de Despesa e ParametroDespesa
- [ ] 6.5 Criar DTOs de Resultado de Cálculo
- [ ] 6.6 Configurar AutoMapper profiles

## 7. Backend .NET - Validações

- [ ] 7.1 Criar FluentValidation para ApartamentoCreateDto (número, bloco, metragem, fração)
- [ ] 7.2 Criar FluentValidation para DadosCobrancaDto (email, telefone)
- [ ] 7.3 Criar FluentValidation para DespesaCreateDto
- [ ] 7.4 Criar FluentValidation para CreditoCreateDto

## 8. Backend .NET - Controllers CRUD Apartamentos

- [ ] 8.1 Implementar GET /api/apartamentos (listar com filtro por bloco)
- [ ] 8.2 Implementar GET /api/apartamentos/{id} (detalhe com dados de cobrança)
- [ ] 8.3 Implementar POST /api/apartamentos (criar com dados de cobrança)
- [ ] 8.4 Implementar PUT /api/apartamentos/{id} (atualizar)
- [ ] 8.5 Implementar DELETE /api/apartamentos/{id} (com validação)

## 9. Backend .NET - Controllers Créditos

- [ ] 9.1 Implementar GET /api/apartamentos/{id}/creditos (listar)
- [ ] 9.2 Implementar POST /api/apartamentos/{id}/creditos (criar)

## 10. Backend .NET - Controllers Despesas

- [ ] 10.1 Implementar GET /api/despesas (listar)
- [ ] 10.2 Implementar POST /api/despesas (criar)
- [ ] 10.3 Implementar PUT /api/despesas/{id} (atualizar regra)
- [ ] 10.4 Implementar DELETE /api/despesas/{id} (desativar)
- [ ] 10.5 Implementar POST /api/parametros-despesa (configurar parâmetros)

## 11. Backend .NET - Engine de Rateio

- [ ] 11.1 Implementar IRateioStrategy interface
- [ ] 11.2 Implementar RateioPorFracaoIdeal
- [ ] 11.3 Implementar RateioIgualitario
- [ ] 11.4 Implementar RateioPercentualFixo
- [ ] 11.5 Implementar RateioFactory para resolver estratégias
- [ ] 11.6 Implementar validações (soma 100%, sem divisão por zero)

## 12. Backend .NET - Engine de Cálculo

- [ ] 12.1 Implementar CalculadorCondominioService
- [ ] 12.2 Implementar carregamento de apartamentos ativos
- [ ] 12.3 Implementar carregamento de despesas ativas
- [ ] 12.4 Implementar aplicação de rateios múltiplos
- [ ] 12.5 Implementar aplicação de descontos por crédito
- [ ] 12.6 Implementar aplicação de ajustes individuais
- [ ] 12.7 Implementar arredondamento sem perda de centavos
- [ ] 12.8 Implementar agrupamento de despesas por tipo

## 13. Backend .NET - Controllers Cálculo

- [ ] 13.1 Implementar POST /api/calculo (executar cálculo novo)
- [ ] 13.2 Implementar GET /api/calculos (listar com filtro por período)
- [ ] 13.3 Implementar GET /api/calculos/{id} (detalhe com breakdown agrupado)
- [ ] 13.4 Implementar POST /api/calculos/{id}/recalcular (recalcular período)

## 14. Backend .NET - Relatórios e Exportação

- [ ] 14.1 Implementar RelatorioService (geração de dados)
- [ ] 14.2 Implementar CsvService (exportar para CSV)
- [ ] 14.3 Implementar PdfService (gerar PDF com memória de cálculo)
- [ ] 14.4 Implementar GET /api/relatorios/consolidado (resumo mensal)
- [ ] 14.5 Implementar GET /api/relatorios/apartamento/{id} (histórico)

## 15. Backend .NET - Email

- [ ] 15.1 Configurar MailKit com Brevo (credenciais)
- [ ] 15.2 Implementar EmailService (enviar email)
- [ ] 15.3 Implementar templates de email com PDF anexado
- [ ] 15.4 Implementar POST /api/calculos/{id}/enviar-emails (disparar envios)
- [ ] 15.5 Implementar rastreamento de envios (EnvioEmail)

## 16. Backend .NET - Testes Unitários

- [ ] 16.1 Testes para RateioPorFracaoIdeal
- [ ] 16.2 Testes para RateioIgualitario
- [ ] 16.3 Testes para aplicação de crédito (desconto correto)
- [ ] 16.4 Testes para CalculadorCondominioService (integração)
- [ ] 16.5 Testes de validação (erro sem apartamentos, sem despesas)

## 17. Frontend React - Setup Inicial

- [ ] 17.1 Instalar dependências (React Router, Axios, Chakra UI, React PDF)
- [ ] 17.2 Estruturar pastas (components, pages, services, hooks, utils)
- [ ] 17.3 Configurar Axios service com baseURL
- [ ] 17.4 Configurar React Router com páginas principais
- [ ] 17.5 Configurar Chakra UI e tema

## 18. Frontend React - Layout

- [ ] 18.1 Criar Header com navegação
- [ ] 18.2 Criar Sidebar com menu principal
- [ ] 18.3 Criar Layout wrapper
- [ ] 18.4 Criar página Home (dashboard básico)

## 19. Frontend React - Página Apartamentos

- [ ] 19.1 Criar página de listagem com tabela
- [ ] 19.2 Criar filtro por bloco
- [ ] 19.3 Criar modal/form para criar apartamento
- [ ] 19.4 Criar modal/form para editar apartamento
- [ ] 19.5 Implementar confirmação de exclusão
- [ ] 19.6 Exibir dados de cobrança e créditos

## 20. Frontend React - Página Despesas

- [ ] 20.1 Criar página de listagem com tabela
- [ ] 20.2 Criar modal/form para criar despesa
- [ ] 20.3 Criar modal/form para editar despesa
- [ ] 20.4 Implementar toggle ativo/inativo
- [ ] 20.5 Criar seção de configuração de parâmetros

## 21. Frontend React - Página Cálculo

- [ ] 21.1 Criar seletor de período (mês/ano)
- [ ] 21.2 Implementar botão "Executar Cálculo" com loading
- [ ] 21.3 Exibir resultado em tabela por apartamento
- [ ] 21.4 Exibir breakdown agrupado por tipo de despesa
- [ ] 21.5 Implementar botão "Exportar CSV"
- [ ] 21.6 Implementar botão "Exportar PDF"
- [ ] 21.7 Implementar aba de simulação
- [ ] 21.8 Exibir aviso se período já foi calculado

## 22. Frontend React - Página Relatórios

- [ ] 22.1 Criar aba "Consolidado" (resumo mensal)
- [ ] 22.2 Criar aba "Por Apartamento" (histórico)
- [ ] 22.3 Criar aba "Análise de Despesas" (gráfico pizza)
- [ ] 22.4 Criar filtros por período
- [ ] 22.5 Implementar botão "Enviar Emails"
- [ ] 22.6 Exibir status de envios

## 23. Frontend React - Componentes

- [ ] 23.1 Criar FormField component
- [ ] 23.2 Criar Table component
- [ ] 23.3 Criar Modal component
- [ ] 23.4 Criar Loading spinner
- [ ] 23.5 Criar Toast notifications

## 24. Frontend React - UI/UX

- [ ] 24.1 Validações no frontend (metragem > 0, email válido, fração positiva)
- [ ] 24.2 Feedback visual (loading, success, error)
- [ ] 24.3 Responsividade mobile
- [ ] 24.4 Mensagens de erro informativos

## 25. Integração e Testes E2E

- [ ] 25.1 Teste: Criar apartamento com dados de cobrança
- [ ] 25.2 Teste: Criar crédito e verificar desconto
- [ ] 25.3 Teste: Criar despesa com parâmetros
- [ ] 25.4 Teste: Executar cálculo completo
- [ ] 25.5 Teste: Validar soma de valores (sem perda)
- [ ] 25.6 Teste: Exportar CSV/PDF
- [ ] 25.7 Teste: Recalcular período anterior
- [ ] 25.8 Teste: Enviar emails com sucesso

## 26. Deploy e Documentação

- [ ] 26.1 Configurar GitHub Actions para build backend
- [ ] 26.2 Deploy backend em Render
- [ ] 26.3 Deploy frontend em Vercel
- [ ] 26.4 Configurar variáveis de ambiente (DB, API URL, Brevo)
- [ ] 26.5 Configurar CORS
- [ ] 26.6 Escrever README (setup local)
- [ ] 26.7 Documentar API (Swagger)
- [ ] 26.8 Teste final em produção
