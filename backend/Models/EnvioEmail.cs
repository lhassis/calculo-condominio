namespace CondominioApi.Models;

public class EnvioEmail
{
    public int Id { get; set; }
    public int CalculoId { get; set; }
    public int ApartamentoId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Assunto { get; set; } = string.Empty;
    public bool EnviadoComSucesso { get; set; } = false;
    public string? MensagemErro { get; set; }
    public DateTime DataEnvio { get; set; } = DateTime.UtcNow;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    // Relationships
    public Calculo Calculo { get; set; } = null!;
    public Apartamento Apartamento { get; set; } = null!;
}
