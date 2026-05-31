namespace CondominioApi.DTOs;

public class ApartamentoResponseDto
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string Bloco { get; set; } = string.Empty;
    public decimal Metragem { get; set; }
    public decimal FracaoIdeal { get; set; }
    public bool Ativo { get; set; }
}

public class ApartamentoCreateDto
{
    public string Numero { get; set; } = string.Empty;
    public string Bloco { get; set; } = string.Empty;
    public decimal Metragem { get; set; }
    public decimal FracaoIdeal { get; set; }
}

public class ApartamentoUpdateDto
{
    public string? Numero { get; set; }
    public string? Bloco { get; set; }
    public decimal? Metragem { get; set; }
    public decimal? FracaoIdeal { get; set; }
    public bool? Ativo { get; set; }
}
