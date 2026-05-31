namespace CondominioApi.Models;

public class Apartamento
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string Bloco { get; set; } = string.Empty;
    public decimal Metragem { get; set; }
    public decimal FracaoIdeal { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }

    // Relationships
    public DadosCobranca? DadosCobranca { get; set; }
    public ICollection<Credito> Creditos { get; set; } = new List<Credito>();
    public ICollection<AjusteApartamento> Ajustes { get; set; } = new List<AjusteApartamento>();
}
