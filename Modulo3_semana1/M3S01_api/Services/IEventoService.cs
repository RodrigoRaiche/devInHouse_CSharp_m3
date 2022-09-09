using M3S01_api.DTO;

namespace M3S01_api.Services;

public interface IEventoService
{
    int Add(EventoPostDto eventoPostDto);

    bool Update(EventoPutDto eventoPutDto);

    bool Delete(int id);

    IList<EventoGetDto> GetAll();
    
    EventoGetDto GetId(int id);
    
    IList<EventoGetPeriodoDto> GetByPeriodo(DateTime dateMax, DateTime dateMin);

}