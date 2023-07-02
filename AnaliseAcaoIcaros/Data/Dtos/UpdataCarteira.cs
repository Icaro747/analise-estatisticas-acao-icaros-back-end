using System.ComponentModel.DataAnnotations;

namespace AnaliseAcaoIcaros.Data.Dtos;

public class UpdataCarteira
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Nome { get; set; }
}
