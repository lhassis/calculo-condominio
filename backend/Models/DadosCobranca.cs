namespace CondominioApi.Models;

public class DadosCobranca
{
    public int Id { get; set; }
    public int ApartamentoId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Contato { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }

    // Relationships
    public Apartamento Apartamento { get; set; } = null!;
}
