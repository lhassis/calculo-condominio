namespace CondominioApi.DTOs;

public class CreditoDto
{
    public int Id { get; set; }
    public int ApartamentoId { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataCredito { get; set; }
    public bool Utilizado { get; set; }
}
