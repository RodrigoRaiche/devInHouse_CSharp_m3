using System.ComponentModel.DataAnnotations;

namespace M3S01_api.DTO;

public record EventoPostDto([Required] int BandaId, [Required] string Descricao, [Required] decimal QuantidadePessoasLocal, [Required] DateTime DataEvento, [Required] int TipoEvento);
