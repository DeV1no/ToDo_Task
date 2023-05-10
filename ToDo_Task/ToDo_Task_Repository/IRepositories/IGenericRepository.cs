namespace ToDo_Task_Repository.IRepositories;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> All();
   // Task<Paging<T>> GetList(GridifyQuery query);
    Task<T?> GetById(int id);
    Task<T> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(int id);
  
}