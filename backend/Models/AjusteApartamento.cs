namespace CondominioApi.Models;

public class AjusteApartamento
{
    public int Id { get; set; }
    public int ApartamentoId { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime Periodo { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }

    // Relationships
    public Apartamento Apartamento { get; set; } = null!;
}
