using API_Assessment.Interface;
using API_Assessment.Models;
using API_Assessment.Repositary;
using System.Linq.Expressions;

namespace API_Assessment.Service
{
    public class Genericservice<T,K> : IGeneric<T, K> where T : class
    {
        private readonly IGeneric<T, K> _GenericRepo;
        public Genericservice(IGeneric<T,K> genericRepo)
        {
            _GenericRepo = genericRepo;
        }  
        public async Task Add(T entity)
        {
            await _GenericRepo.Add(entity);
        }
        public Task Delete(K id)
        {
            return _GenericRepo.Delete(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _GenericRepo.GetAll();
        }
        public async Task<T?> GetById(K id)
        {
            return await _GenericRepo.GetById(id);
        }
        public async Task SavetoDB()
        {
           await _GenericRepo.SavetoDB();   
        }
        public async Task Update(T entity)
        {
             await _GenericRepo.Update(entity);    
        }
        public async Task<DirectorClass?> GetDirectorDetailsById(K id)
        {
            if (typeof(T) != typeof(DirectorClass))
                throw new InvalidOperationException("This method is only valid for DirectorClass.");
            return await (_GenericRepo as GenericRepository<DirectorClass, K>)!.GetDirectorDetailsById(id);
        }
        public async Task<WebseriesClass?> GetWebseriesDetailsById(K id)
        {
            if (typeof(T) != typeof(WebseriesClass))
                throw new InvalidOperationException("This method is only valid for WebseriesClass.");
            return await (_GenericRepo as GenericRepository<WebseriesClass, K>)!.GetWebseriesDetailsById(id);
        }
        public async Task<IEnumerable<T>> GetByCondition(System.Linq.Expressions.Expression<Func<T, bool>> condition)
        {
            return await ((GenericRepository<T, K>)_GenericRepo).GetByCondition(condition);
        }

    }
}
