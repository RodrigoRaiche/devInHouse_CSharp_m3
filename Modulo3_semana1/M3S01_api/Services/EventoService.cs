using System.Text.RegularExpressions;
using M3S01_api.DTO;
using M3S01_api.Models;
using M3S01_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace M3S01_api.Services;

public class EventoService : IEventoService
{
    private readonly IEventoRepository<EventoModel> _eventoRepository;

    public EventoService(IEventoRepository<EventoModel> eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    public int Add(EventoPostDto eventoPostDto)
    {
        
        if (eventoPostDto.BandaId == 0)
            return 0;

        var eventoModel = _eventoRepository.GetByBanda(eventoPostDto.BandaId, eventoPostDto.Descricao);

        if (eventoModel is not null)
         {
           return 0;
         }

       var model = new EventoModel {BandaId = eventoPostDto.BandaId, Descricao = eventoPostDto.Descricao, QuantidadePessoasLocal = eventoPostDto.QuantidadePessoasLocal, DataEvento  = eventoPostDto.DataEvento, TipoEvento = eventoPostDto.TipoEvento};
        _eventoRepository.Add(model);

        return model.Id;

    }

    public bool Update(EventoPutDto eventoPutDto)
    {
        if (eventoPutDto.BandaId == 0)
            return false;
        
        var eventoModel = _eventoRepository.GetByBanda(eventoPutDto.BandaId, eventoPutDto.Descricao);

        if (eventoModel is not null)
        {
            return false;
        }
        
        var model = new EventoModel
        {
            Id = eventoPutDto.Id,
            BandaId = eventoPutDto.BandaId,
            Descricao = eventoPutDto.Descricao,
            QuantidadePessoasLocal = eventoPutDto.QuantidadePessoasLocal,
            DataEvento = eventoPutDto.DataEvento,
            TipoEvento = eventoPutDto.TipoEvento
        };

        return _eventoRepository.Update(model);

    }

    public bool Delete(int id)
    {
        return _eventoRepository.Delete(id);
    }

    public IList<EventoGetDto> GetAll()
    {
        var EventoModel = _eventoRepository.GetAll();
        List<EventoGetDto> returns = new(EventoModel.Select(lambdaExpressio => (EventoGetDto)lambdaExpressio) );
        return returns;
        

    }

    public EventoGetDto GetId(int id)
    {
        var eventoModel = _eventoRepository.GetId(id);
        
        var dto = new EventoGetDto
        {
            DataEvento = eventoModel.DataEvento,
            NomeBanda = eventoModel.BandaModel.Descricao,
            QuantidadePessoasLocal = eventoModel.QuantidadePessoasLocal
          };
        
        return dto;

    }
    
    public IList<EventoGetPeriodoDto> GetByPeriodo(DateTime dateMax, DateTime dateMin)
    {
        
        List<EventoModel> eventoModel = _eventoRepository.GetAll().ToList();

        var listaPeriodo = eventoModel.Where(w => w.DataEvento >= dateMin && w.DataEvento <= dateMax);
        
        List<EventoGetPeriodoDto> listaPeriodoGroup = listaPeriodo
            .GroupBy(x => x.TipoEvento)
            .Select(s => new EventoGetPeriodoDto(s.Min(c => c.DataEvento),s.Max(c => c.DataEvento), s.FirstOrDefault()!.Id, s.FirstOrDefault()!.Descricao,  s.FirstOrDefault()!.QuantidadePessoasLocal, s.FirstOrDefault()!.TipoEvento)).ToList();
        
        
        return listaPeriodoGroup;


    }

}