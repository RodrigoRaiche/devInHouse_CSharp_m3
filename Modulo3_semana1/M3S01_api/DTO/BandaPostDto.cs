using System.ComponentModel.DataAnnotations;

namespace M3S01_api.DTO;

public record BandaPostDto([Required] string Descricao, [Required] int GeneroMusical, [Required] bool Solo);
    
    
