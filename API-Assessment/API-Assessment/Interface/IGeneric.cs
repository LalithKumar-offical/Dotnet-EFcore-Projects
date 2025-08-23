namespace API_Assessment.Interface
{
    public interface IGeneric<T,K>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(K id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(K id);
        Task SavetoDB();

    }
}
