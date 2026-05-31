namespace CondominioApi.DTOs;

public class DadosCobrancaDto
{
    public int Id { get; set; }
    public int ApartamentoId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Contato { get; set; }
}
