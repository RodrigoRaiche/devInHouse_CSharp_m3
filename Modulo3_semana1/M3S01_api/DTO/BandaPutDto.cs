using System.ComponentModel.DataAnnotations;

namespace M3S01_api.DTO;

public class BandaPutDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Descricao { get; set; }
    
    [Required]
    public int GeneroMusical { get; set; }
    
    [Required]
    public bool Solo { get; set; }

    
}