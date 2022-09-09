namespace M3S01_api.Repositories;


public interface IEventoRepository<TEntity> : IEntity<TEntity>
{
    TEntity GetByBanda(int bandaID, string descricaoEvento);
    IList<TEntity> GetByPeriodo(DateTime dateMax, DateTime dateMin);   
}