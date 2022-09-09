using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using M3S01_api.Context;
using M3S01_api.Models;

namespace M3S01_api.Repositories;

public class EventoRepository : IEventoRepository<EventoModel>
{
    private readonly IDbContextFactory<ShowDBContext> _dbContextFactory;

    public EventoRepository(IDbContextFactory<ShowDBContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    
    public int Add(EventoModel model)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            try
            {
                context.Add(model);
                context.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        return model.Id;

    }

    public bool Update(EventoModel model)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            context.Update(model);
            return context.SaveChanges() > 0;
        }


    }

    public bool Delete(int id)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            context.Remove<EventoModel>(new EventoModel { Id = id });
            return context.SaveChanges() > 0;
        }        


    }

    public IList<EventoModel> GetAll()
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            return context.Eventos.Include(x => x.BandaModel).ToList();
        }

    }
    
    public EventoModel GetId(int id)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            return context.Eventos.Include(x => x.BandaModel).FirstOrDefault(y => y.Id == id);
        }

    }
    
    public EventoModel GetByBanda(int id, string descricaoEvento)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            var eventoDesc = context.Eventos.FirstOrDefault(x => x.Descricao == descricaoEvento);

            if (eventoDesc == null)
                return null;
                
            return context.Eventos.FirstOrDefault(y => y.BandaId == id && y.Id == eventoDesc.Id);
        }

    }

    
    public IList<EventoModel> GetByPeriodo(DateTime dateMax, DateTime dateMin)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            return context.Eventos.Include(x => x.BandaModel).ToList();
        }

    }


}