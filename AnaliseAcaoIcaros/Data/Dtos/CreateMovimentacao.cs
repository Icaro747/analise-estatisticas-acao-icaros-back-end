using System.ComponentModel.DataAnnotations;

namespace AnaliseAcaoIcaros.Data.Dtos;

public class CreateMovimentacao
{
    [Required]
    public Guid IdPapel { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public string Operacao { get; set; }
    [Required]
    public int Qtd { get; set; }
    [Required]
    public decimal Valor { get; set; }
    public decimal Taxa { get; set; }
}
