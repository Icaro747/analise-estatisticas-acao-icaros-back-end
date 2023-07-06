using System.ComponentModel.DataAnnotations;

namespace AnaliseAcaoIcaros.Data.Dtos;

public class CreatePepel
{
    [Required]
    public Guid IdCarteira { get; set; }
   
    [Required]
    public string Titulo { get; set; }
    [Required]
    public string Classe { get; set; }
    [Required]
    public string Setor { get; set; }
}
