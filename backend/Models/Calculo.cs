namespace CondominioApi.Models;

public class Calculo
{
    public int Id { get; set; }
    public DateTime Periodo { get; set; }
    public decimal ValorTotal { get; set; }
    public int TotalApartamentos { get; set; }
    public bool Finalizado { get; set; } = false;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }

    // Relationships
    public ICollection<ResultadoCalculo> Resultados { get; set; } = new List<ResultadoCalculo>();
}

public class ResultadoCalculo
{
    public int Id { get; set; }
    public int CalculoId { get; set; }
    public int ApartamentoId { get; set; }
    public decimal ValorDespesas { get; set; }
    public decimal ValorCreditosAplicados { get; set; }
    public decimal ValorAjustes { get; set; }
    public decimal ValorFinal { get; set; }
    public string Detalhamento { get; set; } = string.Empty; // JSON com breakdown das despesas
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    // Relationships
    public Calculo Calculo { get; set; } = null!;
    public Apartamento Apartamento { get; set; } = null!;
}
