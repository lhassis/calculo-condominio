namespace CondominioApi.Models;

public class Despesa
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string Tipo { get; set; } = string.Empty; // "comum", "extraordinaria", etc
    public int RateioPorFracaoIdealId { get; set; }
    public bool Ativa { get; set; } = true;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }

    // Relationships
    public ParametroDespesa ParametroDespesa { get; set; } = null!;
}

public class ParametroDespesa
{
    public int Id { get; set; }
    public int DespesaId { get; set; }
    public string TipoRateio { get; set; } = string.Empty; // "fracao_ideal", "igualitario", "percentual_fixo"
    public decimal? Percentual { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }

    // Relationships
    public Despesa Despesa { get; set; } = null!;
}
