namespace M3S01_api.DTO;

public record EventoGetPeriodoDto(DateTime DataEventoMinima,DateTime DataEventoMaxima, int Id, string Descricao, decimal QuantidadePessoasLocal,
    int TipoEvento);

    


