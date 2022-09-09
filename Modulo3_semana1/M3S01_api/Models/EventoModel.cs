using System.ComponentModel.DataAnnotations.Schema;
using M3S01_api.DTO;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace M3S01_api.Models;

public class EventoModel
{
    public int Id { get; set; }

    [ForeignKey("BandaModel")]
    public int BandaId { get; set; }

    public string Descricao { get; set; }

    public decimal QuantidadePessoasLocal { get; set; }

    public DateTime DataEvento { get; set; }

    public int TipoEvento { get; set; }

    public BandaModel? BandaModel { get; set; }
    
    public static explicit operator EventoGetDto(EventoModel model)
    {
        return new EventoGetDto
        {
            Descricao = model.Descricao,
            DataEvento = model.DataEvento,
            QuantidadePessoasLocal = model.QuantidadePessoasLocal,
            NomeBanda = model.BandaModel.Descricao,
            TipoEvento = model.TipoEvento
            
        };
    }

    


}