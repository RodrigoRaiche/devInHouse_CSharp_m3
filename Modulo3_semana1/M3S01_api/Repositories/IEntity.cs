namespace M3S01_api.Repositories;

public interface IEntity<TModel>
{
    int Add(TModel model);
    bool Update(TModel model);
    bool Delete(int id);
    IList<TModel> GetAll();
    TModel GetId(int id);
}
