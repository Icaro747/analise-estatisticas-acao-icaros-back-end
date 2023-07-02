using Microsoft.Build.Framework;

namespace AnaliseAcaoIcaros.Data.Dtos;

public class CreateCarteira
{
    [Required]
    public string Nome { get; set; }
}
