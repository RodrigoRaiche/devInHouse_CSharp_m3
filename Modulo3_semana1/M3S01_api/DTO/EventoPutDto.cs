using System.ComponentModel.DataAnnotations;

namespace M3S01_api.DTO;

public class EventoPutDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int BandaId { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    public decimal QuantidadePessoasLocal { get; set; }

    [Required]
    public DateTime DataEvento { get; set; }
    
    [Required]
    public int TipoEvento { get; set; }

}