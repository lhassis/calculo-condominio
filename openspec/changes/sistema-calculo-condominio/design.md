## Context

Sistema de cálculo de condomínio que automatiza a distribuição de despesas entre apartamentos conforme regras configuráveis. Envolve múltiplas camadas:
- Frontend React para interface de usuário
- Backend .NET para lógica de negócio e cálculos
- PostgreSQL em nuvem (Neon) para persistência
- Regras de rateio complexas que variam por tipo de despesa

## Goals / Non-Goals

**Goals:**
- Implementar engine de cálculo confiável que suporte múltiplas regras de rateio
- Criar API REST .NET para operações CRUD e cálculos
- Desenvolver interface React intuitiva para gerenciar dados e visualizar resultados
- Garantir persistência em PostgreSQL com integridade referencial
- Suportar hospedagem em nuvem com escalabilidade

**Non-Goals:**
- Sistema de pagamentos ou integração bancária (fora do escopo)
- Suporte a múltiplos condomínios/organizações (primeiro release = single-tenant)
- Auditoria e histórico completo de alterações (será adicionado depois)
- Autenticação/autorização complexa (fase inicial = acesso básico)

## Decisions

**1. Arquitetura em três camadas (Frontend / Backend / Database)**
- *Decision*: Separar completamente frontend (React) de backend (.NET) com API REST
- *Why*: Permite escalabilidade independente, facilita testes, equipes trabalham em paralelo
- *Alternative considered*: Monolito - rejeitado pela complexidade de deployar React e .NET juntos

**2. Regras de cálculo como dados configuráveis (não hardcoded)**
- *Decision*: Armazenar regras de rateio no banco (ex: "taxa por m²", "percentual fixo")
- *Why*: Permite alterar regras sem redeploy; essencial para o domínio de condomínio
- *Alternative considered*: Hardcoded em enums - muito rígido e requer release para mudanças

**3. PostgreSQL com migrations versionadas**
- *Decision*: Schema PostgreSQL com Liquibase ou EF Core migrations
- *Why*: .NET + PostgreSQL é padrão; migrations garantem consistência entre ambientes
- *Alternative considered*: SQL Server - rejeitado; PostgeSQL (Neon) mais barato e portável

**4. API REST com DTOs tipadas**
- *Decision*: Endpoints RESTful com request/response DTOs em .NET
- *Why*: Padrão web moderno; facilita documentação (Swagger); cliente React consome facilmente
- *Alternative considered*: GraphQL - complexo demais para fase inicial

**5. Cálculo como operação síncrona com persistência**
- *Decision*: POST /api/calcular retorna resultado e persiste no banco de dados (não fila/async)
- *Why*: Simples para começar; despesas de condomínio não são high-volume (1x mês típico). A persistência é importante para gerar relatórios futuros ou conferências.
- *Alternative considered*: Background job - overkill nesta fase

**6. Operação de recálculo**
- *Decision*: POST /api/recalcular retorna resultado e persiste no banco de dados uma nova versão do cálculo para o mês considerado e torna essa versão ativa(não fila/async)
- *Why*: Importante para manter o histórico.
- *Alternative considered*: Background job - overkill nesta fase

**7. Hospedagem dos serviços**
- *Decision*: API: Render / Frontend: Vercel
- *Why*: gratuitos e apropriados para projetos de portifólio
- *Alternative considered*: Railway / Netlify. Possuem planos gratuitos mais instáveis com relação as regras de gratuidade.

**8. Biblioteca de componentes frontend**
- *Decision*: Chackra UI
- *Why*: gratuito, com boa variedade de componentes fácil customização
- *Alternative considered*: Antd. Possui histórico de breaking changes.

**9. Frontend boiler plate**
- *Decision*: Vite
- *Why*: simples e já possui aderência prévia dos desenvolvedores envolvidos
- *Alternative considered*: Create React App. Deprecated

**10. Serviço SMTP**
- *Decision*: Brevo usando biblioteca MailKit
- *Why*: configuração simples e biblioteca bem documentada

## Risks / Trade-offs

| Risk | Mitigation |
|------|-----------|
| Regras de rateio mal definidas → cálculos incorretos | Specs.md detalha validações e cases de teste |
| Performance com muitos apartamentos (1000+) | Índices no banco em FK; otimizar queries depois se necessário |
| Mudanças na regra de rateio quebram cálculos históricos | Adicionar versionamento de regras em próxima sprint |
| Acesso sem autenticação | MVP = single user; autenticação adicionada em next sprint |
| PostgreSQL em nuvem (Neon) - novo para a equipe | Documentar conexão e failover; usar ORMs para abstração |

## Migration Plan

**Deploy inicial (MVP):**
1. Criar schema PostgreSQL (Neon) com tabelas de apartamentos, despesas, regras
2. Deploy backend .NET em nuvem (ex: Azure App Service ou Heroku)
3. Deploy frontend React em CDN/static hosting (ex: Vercel, Azure Static Web Apps)
4. Teste integrado: criar apartamentos via API → calcular → validar resultados

**Rollback:** Se algo falhar, revert git + revert migration + redeploy anterior

## Open Questions

- [ ] Qual o máximo de apartamentos esperado no MVP?
- [ ] Há histórico de cálculos que precisa ser preservado ou começa do zero?
- [ ] Validações específicas de negócio que faltam (ex: despesa negativa?)?
