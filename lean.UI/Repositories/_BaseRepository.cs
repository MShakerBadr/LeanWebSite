using lean.UI.Context;
using lean.UI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace lean.UI.Repositories
{
    public class BaseRepository
    {
        private readonly LeanDbContext _context;

        public BaseRepository(LeanDbContext context)
        {
            _context = context;
            
        }

        private IQueryable<T> InsializeQuery<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        //all
        public List<T> GetAll<T>() where T : class
        {
            return InsializeQuery<T>().ToList();
        }
        public List<T> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            return InsializeQuery(includes).ToList<T>();
        }
        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            return await InsializeQuery<T>().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            return await InsializeQuery(includes).ToListAsync();
        }
        public IQueryable<T> GetQuery<T>() where T : class
        {
            return InsializeQuery<T>();
        }
        public IQueryable<T> GetQuery<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            return InsializeQuery<T>(includes);
        }
        //all where
        public List<T> GetAllWhere<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return InsializeQuery<T>().Where(predicate).AsNoTracking().ToList();
        }
        public List<T> GetAllWhere<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            return InsializeQuery<T>(includes).Where(predicate).ToList();
        }
        public async Task<List<T>> GetAllWhereAsync<T>(Expression<Func<T, bool>> predicate, bool desc) where T : Entity
        {
            if (desc)
                return await InsializeQuery<T>().Where(predicate).OrderByDescending(x => x.Id).ToListAsync();
            else
                return await InsializeQuery<T>().Where(predicate).ToListAsync();
        }
        public async Task<List<T>> GetAllWhereAsync<T>(Expression<Func<T, bool>> predicate, bool desc, params Expression<Func<T, object>>[] includes) where T : Entity
        {
            if (desc)
                return await InsializeQuery<T>(includes).OrderByDescending(x => x.Id).Where(predicate).ToListAsync();
            else
                return await InsializeQuery<T>(includes).Where(predicate).ToListAsync();
        }
        public IQueryable<T> GetQueryWhere<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return InsializeQuery<T>().Where(predicate);
        }
        public IQueryable<T> GetQueryWhere<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            return InsializeQuery<T>(includes).Where(predicate);
        }
        //all with paging
        public virtual List<T> GetAllWithPaging<T>(int skip, int take, bool desc) where T : Entity
        {
            if (desc)
                return InsializeQuery<T>().OrderByDescending(x => x.Id).Skip(skip).Take(take).ToList();
            else
                return InsializeQuery<T>().OrderBy(x => x.Id).Skip(skip).Take(take).ToList();
        }
        public virtual List<T> GetAllWithPaging<T>(int skip, int take, bool desc, params Expression<Func<T, object>>[] includes) where T : Entity
        {
            if (desc)
                return InsializeQuery(includes).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToList<T>();
            else
                return InsializeQuery(includes).OrderBy(x => x.Id).Skip(skip).Take(take).ToList<T>();
        }
        public virtual async Task<List<T>> GetAllWithPagingAsync<T>(int skip, int take, bool desc) where T : Entity
        {
            if (desc)
                return await InsializeQuery<T>().OrderByDescending(x => x.Id).Skip(skip).Take(take).ToListAsync();
            else
                return await InsializeQuery<T>().OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }
        public virtual async Task<List<T>> GetAllWithPagingAsync<T>(int skip, int take, bool desc, params Expression<Func<T, object>>[] includes) where T : Entity
        {
            if (desc)
                return await InsializeQuery(includes).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToListAsync();
            else
                return await InsializeQuery(includes).OrderBy(x => x.Id).Skip(skip).Take(take).ToListAsync();
        }
        //all with paging where
        public virtual List<T> GetAllWithPagingWhere<T>(Expression<Func<T, bool>> predicate, int skip, int take, bool desc) where T : Entity
        {
            if (desc)
                return InsializeQuery<T>().OrderByDescending(x => x.Id).Skip(skip).Take(take).Where(predicate).ToList();
            else
                return InsializeQuery<T>().OrderBy(x => x.Id).Skip(skip).Take(take).Where(predicate).ToList();
        }
        public virtual List<T> GetAllWithPagingWhere<T>(Expression<Func<T, bool>> predicate, int skip, int take, bool desc, params Expression<Func<T, object>>[] includes) where T : Entity
        {
            if (desc)
                return InsializeQuery<T>(includes).OrderByDescending(x => x.Id).Skip(skip).Take(take).Where(predicate).ToList();
            else
                return InsializeQuery<T>(includes).OrderBy(x => x.Id).Skip(skip).Take(take).Where(predicate).ToList();
        }
        public virtual async Task<List<T>> GetAllWithPagingWhereAsync<T>(Expression<Func<T, bool>> predicate, int skip, int take, bool desc) where T : Entity
        {
            if (desc)
                return await InsializeQuery<T>().OrderByDescending(x => x.Id).Skip(skip).Take(take).Where(predicate).ToListAsync();
            else
                return await InsializeQuery<T>().OrderBy(x => x.Id).Skip(skip).Take(take).Where(predicate).ToListAsync();
        }
        public virtual async Task<List<T>> GetAllWithPagingWhereAsync<T>(Expression<Func<T, bool>> predicate, int skip, int take, bool desc, params Expression<Func<T, object>>[] includes) where T : Entity
        {
            if (desc)
                return await InsializeQuery<T>(includes).OrderByDescending(x => x.Id).Skip(skip).Take(take).Where(predicate).ToListAsync();
            else
                return await InsializeQuery<T>(includes).OrderBy(x => x.Id).Skip(skip).Take(take).Where(predicate).ToListAsync();
        }
        //From SQL
        public List<T> FromSQL<T>(string sp) where T : class
        {
            return _context.Set<T>().SqlQuery(sp).ToList();
        }
        //first or default
        public T FirstOrDefault<T>() where T : class
        {
            return _context.Set<T>().FirstOrDefault();
        }
        public T FirstOrDefault<T>(long Id) where T : class
        {
            var data = _context.Set<T>().Find(Id);
            return data ;
        }
        public T FirstOrDefaultAsNoTracking<T>(long Id) where T : Entity
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == Id);
        }
        public T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return InsializeQuery<T>().FirstOrDefault(predicate);
        }
        public T FirstOrDefault<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            return InsializeQuery(includes).FirstOrDefault(predicate);
        }
        public async Task<T> FirstOrDefaultAsync<T>() where T : class
        {
            return await _context.Set<T>().FirstOrDefaultAsync();
        }
        public async Task<T> FirstOrDefaultAsync<T>(long Id) where T : class
        {
            return await _context.Set<T>().FindAsync(Id);
        }
        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await InsializeQuery<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            return await InsializeQuery(includes).FirstOrDefaultAsync(predicate);
        }
        //any
        public bool Any<T>() where T : class
        {
            return InsializeQuery<T>().Any();
        }
        public bool Any<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return InsializeQuery<T>().Any(predicate);
        }
        public async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await InsializeQuery<T>().AnyAsync(predicate);
        }
        //count
        public virtual int Count<T>() where T : Entity
        {
            return InsializeQuery<T>().Count();
        }
        public virtual int Count<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            return InsializeQuery<T>().Where(predicate).Count();
        }
        public virtual async Task<int> CountAsync<T>() where T : Entity
        {
            return await InsializeQuery<T>().CountAsync();
        }
        public virtual async Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            return await InsializeQuery<T>().Where(predicate).CountAsync();
        }
        //add
        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange<T>(List<T> entities) where T : class
        {
            _context.Set<T>().AddRange(entities);
        }
        //update
        public void Update<T>(T entity) where T : class
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
        public void UpdateRange<T>(List<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Modified;
            }
        }
        //remove
        public void Remove<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.Set<T>().Remove(entity);
        }
        public void Remove<T>(long Id) where T : class
        {
            var entity = FirstOrDefault<T>(Id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.Set<T>().Remove(entity);
            }
        }
        public void Remove<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            T entity = FirstOrDefault(predicate);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.Set<T>().Remove(entity);
            }
        }
        public async Task RemoveAsync<T>(long Id) where T : class
        {
            var entity = await FirstOrDefaultAsync<T>(Id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.Set<T>().Remove(entity);
        }
        public async Task RemoveAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            T entity = await FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.Set<T>().Remove(entity);
            }
        }
        public void RemoveRange<T>(List<T> entities) where T : class
        {
            entities.ForEach(x => _context.Entry(x).State = EntityState.Deleted);
            _context.Set<T>().RemoveRange(entities);
        }
        //remove flag
        public void RemoveFlag<T>(long Id) where T : class
        {
            var entity = FirstOrDefault<T>(Id);
            if (entity != null)
            {
                _context.Entry<T>(entity).State = EntityState.Modified;
            }
        }
        public void RemoveFlag<T>(T entity) where T : class
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
        public void RemoveFlagRange<T>(List<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Modified;
            }
        }
        //save changes
        public bool SaveChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                //Logger.GetLogger().Error(ex);

                throw new Exception("Save Entity Exception:", ex);
            }
        }
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                //Logger.GetLogger().Error(ex);
                throw new Exception("Save Entity Exception:", ex);
            }
        }
    }
}