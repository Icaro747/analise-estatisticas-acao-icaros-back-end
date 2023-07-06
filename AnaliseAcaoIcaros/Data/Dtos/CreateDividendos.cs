using System.ComponentModel.DataAnnotations;

namespace AnaliseAcaoIcaros.Data.Dtos;

public class CreateDividendos
{
    [Required]
    public Guid IdPapel { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public decimal Valor { get; set; }
}
