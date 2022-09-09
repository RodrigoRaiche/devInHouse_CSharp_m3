using M3S01_api.DTO;

namespace M3S01_api.Models;

public class BandaModel
{
    public int Id { get; set; }

    public string Descricao { get; set; }
    
    public int GeneroMusical { get; set; }
    
    public bool Solo { get; set; }
    
    public static explicit operator BandaGetDto(BandaModel model)
    {
        return new BandaGetDto
        {
            Id = model.Id,
            Descricao = model.Descricao,
            GeneroMusical = model.GeneroMusical
        };
    }


}