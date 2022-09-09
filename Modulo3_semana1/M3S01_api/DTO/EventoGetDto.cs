namespace M3S01_api.DTO;

public class EventoGetDto
{
    public string Descricao { get; set; }
    public string NomeBanda { get; set; }

    public decimal QuantidadePessoasLocal { get; set; }

    public DateTime DataEvento { get; set; }

    public int TipoEvento { get; set; }

}