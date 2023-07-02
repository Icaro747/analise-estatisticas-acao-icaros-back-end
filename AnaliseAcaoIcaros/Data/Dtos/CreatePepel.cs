using System.ComponentModel.DataAnnotations;

namespace AnaliseAcaoIcaros.Data.Dtos;

public class CreatePepel
{
    [Required]
    public Guid IdCarteira { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public string Operacao { get; set; }
    [Required]
    public string Titulo { get; set; }
    [Required]
    public string Classe { get; set; }
    [Required]
    public int Qtd { get; set; }
    [Required]
    public decimal Valor { get; set; }
    public decimal Taxa { get; set; }
    [Required]
    public string Setor { get; set; }
}
