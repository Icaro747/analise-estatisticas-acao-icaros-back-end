using System.ComponentModel.DataAnnotations;

namespace AnaliseAcaoIcaros.Data.Dtos;

public class CreateCotacao
{
    [Required]
    public string Acao { get; set; }
    [Required]
    public decimal ValorAtual { get; set; }
    [Required]
    public DateTime DataObtida { get; set; }
}
