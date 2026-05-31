using Microsoft.EntityFrameworkCore;
using CondominioApi.Models;

namespace CondominioApi.Data;

public class CondominioDbContext : DbContext
{
    public CondominioDbContext(DbContextOptions<CondominioDbContext> options)
        : base(options)
    {
    }

    public DbSet<Apartamento> Apartamentos { get; set; }
    public DbSet<DadosCobranca> DadosCobranca { get; set; }
    public DbSet<Credito> Creditos { get; set; }
    public DbSet<Despesa> Despesas { get; set; }
    public DbSet<ParametroDespesa> ParametrosDespesa { get; set; }
    public DbSet<Calculo> Calculos { get; set; }
    public DbSet<ResultadoCalculo> ResultadosCalculo { get; set; }
    public DbSet<AjusteApartamento> AjustesApartamento { get; set; }
    public DbSet<EnvioEmail> EnviosEmail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apartamentos
        modelBuilder.Entity<Apartamento>()
            .ToTable("apartamentos")
            .HasKey(a => a.Id);

        modelBuilder.Entity<Apartamento>()
            .Property(a => a.Id)
            .HasColumnName("id");

        modelBuilder.Entity<Apartamento>()
            .Property(a => a.Numero)
            .HasColumnName("numero")
            .HasMaxLength(10)
            .IsRequired();

        modelBuilder.Entity<Apartamento>()
            .Property(a => a.Bloco)
            .HasColumnName("bloco")
            .HasMaxLength(10)
            .IsRequired();

        modelBuilder.Entity<Apartamento>()
            .Property(a => a.Metragem)
            .HasColumnName("metragem")
            .HasPrecision(10, 2);

        modelBuilder.Entity<Apartamento>()
            .Property(a => a.FracaoIdeal)
            .HasColumnName("fracao_ideal")
            .HasPrecision(10, 6);

        modelBuilder.Entity<Apartamento>()
            .Property(a => a.Ativo)
            .HasColumnName("ativo")
            .HasDefaultValue(true);

        modelBuilder.Entity<Apartamento>()
            .Property(a => a.CriadoEm)
            .HasColumnName("criado_em")
            .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

        modelBuilder.Entity<Apartamento>()
            .Property(a => a.AtualizadoEm)
            .HasColumnName("atualizado_em");

        // DadosCobranca
        modelBuilder.Entity<DadosCobranca>()
            .ToTable("dados_cobranca")
            .HasKey(d => d.Id);

        modelBuilder.Entity<DadosCobranca>()
            .Property(d => d.Id)
            .HasColumnName("id");

        modelBuilder.Entity<DadosCobranca>()
            .Property(d => d.ApartamentoId)
            .HasColumnName("apartamento_id");

        modelBuilder.Entity<DadosCobranca>()
            .Property(d => d.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<DadosCobranca>()
            .Property(d => d.Telefone)
            .HasColumnName("telefone")
            .HasMaxLength(20);

        modelBuilder.Entity<DadosCobranca>()
            .Property(d => d.Contato)
            .HasColumnName("contato")
            .HasMaxLength(255);

        modelBuilder.Entity<DadosCobranca>()
            .Property(d => d.CriadoEm)
            .HasColumnName("criado_em")
            .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

        modelBuilder.Entity<DadosCobranca>()
            .Property(d => d.AtualizadoEm)
            .HasColumnName("atualizado_em");

        modelBuilder.Entity<DadosCobranca>()
            .HasOne(d => d.Apartamento)
            .WithOne(a => a.DadosCobranca)
            .HasForeignKey<DadosCobranca>(d => d.ApartamentoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Creditos
        modelBuilder.Entity<Credito>()
            .ToTable("creditos")
            .HasKey(c => c.Id);

        modelBuilder.Entity<Credito>()
            .Property(c => c.Id)
            .HasColumnName("id");

        modelBuilder.Entity<Credito>()
            .Property(c => c.ApartamentoId)
            .HasColumnName("apartamento_id");

        modelBuilder.Entity<Credito>()
            .Property(c => c.Valor)
            .HasColumnName("valor")
            .HasPrecision(12, 2);

        modelBuilder.Entity<Credito>()
            .Property(c => c.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(500);

        modelBuilder.Entity<Credito>()
            .Property(c => c.DataCredito)
            .HasColumnName("data_credito");

        modelBuilder.Entity<Credito>()
            .Property(c => c.Utilizado)
            .HasColumnName("utilizado")
            .HasDefaultValue(false);

        modelBuilder.Entity<Credito>()
            .Property(c => c.CriadoEm)
            .HasColumnName("criado_em")
            .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

        modelBuilder.Entity<Credito>()
            .Property(c => c.AtualizadoEm)
            .HasColumnName("atualizado_em");

        modelBuilder.Entity<Credito>()
            .HasOne(c => c.Apartamento)
            .WithMany(a => a.Creditos)
            .HasForeignKey(c => c.ApartamentoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Despesas
        modelBuilder.Entity<Despesa>()
            .ToTable("despesas")
            .HasKey(d => d.Id);

        modelBuilder.Entity<Despesa>()
            .Property(d => d.Id)
            .HasColumnName("id");

        modelBuilder.Entity<Despesa>()
            .Property(d => d.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(500)
            .IsRequired();

        modelBuilder.Entity<Despesa>()
            .Property(d => d.Valor)
            .HasColumnName("valor")
            .HasPrecision(12, 2);

        modelBuilder.Entity<Despesa>()
            .Property(d => d.Tipo)
            .HasColumnName("tipo")
            .HasMaxLength(50);

        modelBuilder.Entity<Despesa>()
            .Property(d => d.RateioPorFracaoIdealId)
            .HasColumnName("rateio_por_fracao_ideal_id");

        modelBuilder.Entity<Despesa>()
            .Property(d => d.Ativa)
            .HasColumnName("ativa")
            .HasDefaultValue(true);

        modelBuilder.Entity<Despesa>()
            .Property(d => d.CriadoEm)
            .HasColumnName("criado_em")
            .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

        modelBuilder.Entity<Despesa>()
            .Property(d => d.AtualizadoEm)
            .HasColumnName("atualizado_em");

        // ParametrosDespesa
        modelBuilder.Entity<ParametroDespesa>()
            .ToTable("parametros_despesa")
            .HasKey(p => p.Id);

        modelBuilder.Entity<ParametroDespesa>()
            .Property(p => p.Id)
            .HasColumnName("id");

        modelBuilder.Entity<ParametroDespesa>()
            .Property(p => p.DespesaId)
            .HasColumnName("despesa_id");

        modelBuilder.Entity<ParametroDespesa>()
            .Property(p => p.TipoRateio)
            .HasColumnName("tipo_rateio")
            .HasMaxLength(50);

        modelBuilder.Entity<ParametroDespesa>()
            .Property(p => p.Percentual)
            .HasColumnName("percentual")
            .HasPrecision(5, 2);

        modelBuilder.Entity<ParametroDespesa>()
            .Property(p => p.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(500);

        modelBuilder.Entity<ParametroDespesa>()
            .Property(p => p.CriadoEm)
            .HasColumnName("criado_em")
            .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

        modelBuilder.Entity<ParametroDespesa>()
            .Property(p => p.AtualizadoEm)
            .HasColumnName("atualizado_em");

        modelBuilder.Entity<ParametroDespesa>()
            .HasOne(p => p.Despesa)
            .WithOne(d => d.ParametroDespesa)
            .HasForeignKey<ParametroDespesa>(p => p.DespesaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Calculos
        modelBuilder.Entity<Calculo>()
            .ToTable("calculos")
            .HasKey(c => c.Id);

        modelBuilder.Entity<Calculo>()
            .Property(c => c.Id)
            .HasColumnName("id");

        modelBuilder.Entity<Calculo>()
            .Property(c => c.Periodo)
            .HasColumnName("periodo");

        modelBuilder.Entity<Calculo>()
            .Property(c => c.ValorTotal)
            .HasColumnName("valor_total")
            .HasPrecision(12, 2);

        modelBuilder.Entity<Calculo>()
            .Property(c => c.TotalApartamentos)
            .HasColumnName("total_apartamentos");

        modelBuilder.Entity<Calculo>()
            .Property(c => c.Finalizado)
            .HasColumnName("finalizado")
            .HasDefaultValue(false);

        modelBuilder.Entity<Calculo>()
            .Property(c => c.CriadoEm)
            .HasColumnName("criado_em")
            .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

        modelBuilder.Entity<Calculo>()
            .Property(c => c.AtualizadoEm)
            .HasColumnName("atualizado_em");

        // ResultadosCalculo
        modelBuilder.Entity<ResultadoCalculo>()
            .ToTable("resultados_calculo")
            .HasKey(r => r.Id);

        modelBuilder.Entity<ResultadoCalculo>()
            .Property(r => r.Id)
            .HasColumnName("id");

        modelBuilder.Entity<ResultadoCalculo>()
            .Property(r => r.CalculoId)
            .HasColumnName("calculo_id");

        modelBuilder.Entity<ResultadoCalculo>()
            .Property(r => r.ApartamentoId)
            .HasColumnName("apartamento_id");

        modelBuilder.Entity<ResultadoCalculo>()
            .Property(r => r.ValorDespesas)
            .HasColumnName("valor_despesas")
            .HasPrecision(12, 2);

        modelBuilder.Entity<ResultadoCalculo>()
            .Property(r => r.ValorCreditosAplicados)
            .HasColumnName("valor_creditos_aplicados")
            .HasPrecision(12, 2);

        modelBuilder.Entity<ResultadoCalculo>()
            .Property(r => r.ValorAjustes)
            .HasColumnName("valor_ajustes")
            .HasPrecision(12, 2);

        modelBuilder.Entity<ResultadoCalculo>()
            .Property(r => r.ValorFinal)
            .HasColumnName("valor_final")
            .HasPrecision(12, 2);

        modelBuilder.Entity<ResultadoCalculo>()
            .Property(r => r.Detalhamento)
            .HasColumnName("detalhamento")
            .HasColumnType("text");

        modelBuilder.Entity<ResultadoCalculo>()
            .Property(r => r.CriadoEm)
            .HasColumnName("criado_em")
            .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

        modelBuilder.Entity<ResultadoCalculo>()
            .HasOne(r => r.Calculo)
            .WithMany(c => c.Resultados)
            .HasForeignKey(r => r.CalculoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ResultadoCalculo>()
            .HasOne(r => r.Apartamento)
            .WithMany()
            .HasForeignKey(r => r.ApartamentoId)
            .OnDelete(DeleteBehavior.Restrict);

        // AjustesApartamento
        modelBuilder.Entity<AjusteApartamento>()
            .ToTable("ajustes_apartamento")
            .HasKey(a => a.Id);

        modelBuilder.Entity<AjusteApartamento>()
            .Property(a => a.Id)
            .HasColumnName("id");

        modelBuilder.Entity<AjusteApartamento>()
            .Property(a => a.ApartamentoId)
            .HasColumnName("apartamento_id");

        modelBuilder.Entity<AjusteApartamento>()
            .Property(a => a.Valor)
            .HasColumnName("valor")
            .HasPrecision(12, 2);

        modelBuilder.Entity<AjusteApartamento>()
            .Property(a => a.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(500);

        modelBuilder.Entity<AjusteApartamento>()
            .Property(a => a.Periodo)
            .HasColumnName("periodo");

        modelBuilder.Entity<AjusteApartamento>()
            .Property(a => a.Ativo)
            .HasColumnName("ativo")
            .HasDefaultValue(true);

        modelBuilder.Entity<AjusteApartamento>()
            .Property(a => a.CriadoEm)
            .HasColumnName("criado_em")
            .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

        modelBuilder.Entity<AjusteApartamento>()
            .Property(a => a.AtualizadoEm)
            .HasColumnName("atualizado_em");

        modelBuilder.Entity<AjusteApartamento>()
            .HasOne(a => a.Apartamento)
            .WithMany(ap => ap.Ajustes)
            .HasForeignKey(a => a.ApartamentoId)
            .OnDelete(DeleteBehavior.Cascade);

        // EnviosEmail
        modelBuilder.Entity<EnvioEmail>()
            .ToTable("envios_email")
            .HasKey(e => e.Id);

        modelBuilder.Entity<EnvioEmail>()
            .Property(e => e.Id)
            .HasColumnName("id");

        modelBuilder.Entity<EnvioEmail>()
            .Property(e => e.CalculoId)
            .HasColumnName("calculo_id");

        modelBuilder.Entity<EnvioEmail>()
            .Property(e => e.ApartamentoId)
            .HasColumnName("apartamento_id");

        modelBuilder.Entity<EnvioEmail>()
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<EnvioEmail>()
            .Property(e => e.Assunto)
            .HasColumnName("assunto")
            .HasMaxLength(255);

        modelBuilder.Entity<EnvioEmail>()
            .Property(e => e.EnviadoComSucesso)
            .HasColumnName("enviado_com_sucesso")
            .HasDefaultValue(false);

        modelBuilder.Entity<EnvioEmail>()
            .Property(e => e.MensagemErro)
            .HasColumnName("mensagem_erro")
            .HasColumnType("text");

        modelBuilder.Entity<EnvioEmail>()
            .Property(e => e.DataEnvio)
            .HasColumnName("data_envio");

        modelBuilder.Entity<EnvioEmail>()
            .Property(e => e.CriadoEm)
            .HasColumnName("criado_em")
            .HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");

        modelBuilder.Entity<EnvioEmail>()
            .HasOne(e => e.Calculo)
            .WithMany()
            .HasForeignKey(e => e.CalculoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EnvioEmail>()
            .HasOne(e => e.Apartamento)
            .WithMany()
            .HasForeignKey(e => e.ApartamentoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índices
        modelBuilder.Entity<Apartamento>()
            .HasIndex(a => new { a.Bloco, a.Numero })
            .IsUnique();

        modelBuilder.Entity<DadosCobranca>()
            .HasIndex(d => d.Email);

        modelBuilder.Entity<Credito>()
            .HasIndex(c => c.ApartamentoId);

        modelBuilder.Entity<Despesa>()
            .HasIndex(d => d.Ativa);

        modelBuilder.Entity<Calculo>()
            .HasIndex(c => c.Periodo);

        modelBuilder.Entity<ResultadoCalculo>()
            .HasIndex(r => new { r.CalculoId, r.ApartamentoId })
            .IsUnique();

        modelBuilder.Entity<AjusteApartamento>()
            .HasIndex(a => new { a.ApartamentoId, a.Periodo });

        modelBuilder.Entity<EnvioEmail>()
            .HasIndex(e => e.CalculoId);
    }
}
