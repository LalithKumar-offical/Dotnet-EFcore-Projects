using API_Assessment.Data;
using API_Assessment.Interface;
using Microsoft.EntityFrameworkCore;
using API_Assessment.Models;

namespace API_Assessment.Repositary
{
    public class GenericRepository<T, K> : IGeneric<T, K> where T : class
    {
        private readonly CodeContextData _CodeContext;
        private readonly DbSet<T> _dbvalues;

        public GenericRepository(CodeContextData codeContext)
        {
            _CodeContext = codeContext ?? throw new ArgumentNullException(nameof(codeContext));
            _dbvalues = _CodeContext.Set<T>();
        }

        public async Task SavetoDB()
        {
            try
            {
                await _CodeContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving changes to the database: {ex.Message}", ex);
            }
        }

        public async Task Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Cannot add a null entity.");

            try
            {
                await _dbvalues.AddAsync(entity);
                await SavetoDB();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add entity: {ex.Message}", ex);
            }
        }

        public async Task Delete(K id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "ID cannot be null.");

            var entity = await _dbvalues.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID '{id}' not found.");

            try
            {
                _dbvalues.Remove(entity);
                await SavetoDB();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete entity with ID '{id}': {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _dbvalues.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve entities: {ex.Message}", ex);
            }
        }

        public async Task<T?> GetById(K id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "ID cannot be null.");

            try
            {
                var entity = await _dbvalues.FindAsync(id);
                if (entity == null)
                    throw new KeyNotFoundException($"Entity with ID '{id}' not found.");
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve entity with ID '{id}': {ex.Message}", ex);
            }
        }

        public async Task Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Cannot update a null entity.");

            try
            {
                _dbvalues.Attach(entity);
                _CodeContext.Entry(entity).State = EntityState.Modified;
                await SavetoDB();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update entity: {ex.Message}", ex);
            }
        }

public async Task<DirectorClass?> GetDirectorDetailsById(K id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id), "ID cannot be null.");

        try
        {
            var director = await _CodeContext.DbDirector.Include(d => d.WebseriesInstance)
                    .ThenInclude(w => w.SeasonsInstance)
                .Include(d => d.WebseriesInstance)
                    .ThenInclude(w => w.RatingInstance)
                .FirstOrDefaultAsync(d => d.DirectorId.Equals(id));

            if (director == null)
                throw new KeyNotFoundException($"Director with ID '{id}' not found.");

            return director;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to retrieve director details with ID '{id}': {ex.Message}", ex);
        }
    }
        public async Task<WebseriesClass?> GetWebseriesDetailsById(K id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "ID cannot be null.");

            try
            {
                var webseries = await _CodeContext.DbWebseries
                    .Include(w => w.DirectorInstance)          
                    .Include(w => w.SeasonsInstance)           
                    .Include(w => w.RatingInstance)            
                    .FirstOrDefaultAsync(w => w.WebseriesId.Equals(id));

                if (webseries == null)
                    throw new KeyNotFoundException($"Webseries with ID '{id}' not found.");

                return webseries;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve webseries details with ID '{id}': {ex.Message}", ex);
            }
        }
        public async Task<IEnumerable<T>> GetByCondition(System.Linq.Expressions.Expression<Func<T, bool>> condition)
        {
            return await _dbvalues.Where(condition).ToListAsync();
        }
    }
}
