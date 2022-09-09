using Microsoft.EntityFrameworkCore;
using M3S01_api.Context;
using M3S01_api.Models;

namespace M3S01_api.Repositories;

public class BandaRepository : IBandaRepository<BandaModel>
{
    
    private readonly IDbContextFactory<ShowDBContext> _dbContextFactory;

    public BandaRepository(IDbContextFactory<ShowDBContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public int Add(BandaModel model)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            context.Add(model);
            context.SaveChanges();
        }

        return model.Id;

    }

    public bool Update(BandaModel model)
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
            var eventoModelo = context.Eventos.FirstOrDefault(y => y.BandaId == id);

            if (eventoModelo is not null)
                return false;
            
            context.Remove<BandaModel>(new BandaModel { Id = id });
            return context.SaveChanges() > 0;
        }        


    }
    
    public IList<BandaModel> GetAll()
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            return context.Bandas.ToList();
        }
    }
    
    
    public BandaModel GetId(int id)
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            return context.Bandas.FirstOrDefault(y => y.Id == id);
        }

    }



    public IList<BandaModel> BuscarPorMaiorPreco()
    {
        throw new NotImplementedException();
    }
}