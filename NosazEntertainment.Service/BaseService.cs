using Microsoft.EntityFrameworkCore;
using NosazEntertainment.Data;
using NosazEntertainment.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NosazEntertainment.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<bool> CheckExistAsync(params object[] key);
        Task<bool> DeleteAsync(params object[] key);
        Task<bool> DeleteAsync(TEntity model, bool saveNow);
        Task<TEntity> FindAsync(params object[] key);
        TEntity Find(params object[] key);
        Task<TEntity> InsertAsync(TEntity model);
        Task<TEntity> InsertAsync(TEntity model, bool saveNow);
        Task<TEntity> UpdateAsync(TEntity newModel, params object[] key);
        Task<TEntity> UpdateAsync(TEntity model, bool saveNow);
        Task<int> GetMaxKeyAsync(Expression<Func<TEntity, int>> keySelector);
        Task<long> GetMaxKeyAsync(Expression<Func<TEntity, long>> keySelector);
        Task<TEntity> FindAsyncAsNoTracking(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> InsertRangeAsync(List<TEntity> list, bool saveNow);
        Task<List<TEntity>> UpdateRangeAsync(List<TEntity> list, bool saveNow);
        Task<bool> DeleteRangeAsync(List<TEntity> list, bool saveNow);
    }
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
            _dbSet = _uow.Set<TEntity>();
        }

        public virtual async Task<bool> CheckExistAsync(params object[] key)
        {
            return await _dbSet.FindAsync(key) != null;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity model)
        {
            _dbSet.Add(model);
            try
            {
                await _uow.SaveAllChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ForegroundColor = ConsoleColor.Black;
                throw new Exception("خطای سیستمی",innerException: ex);
            }
        }

        public async Task<TEntity> InsertAsync(TEntity model, bool saveNow)
        {
            _dbSet.Add(model);
            if (saveNow)
            {
                try
                {
                    await _uow.SaveAllChangesAsync();
                    return model;
                }
                catch (Exception ex)
                {
                    throw new Exception("خطای سیستمی", innerException: ex);
                }
            }
            return model;
            return model;
        }

        public virtual async Task<bool> DeleteAsync(params object[] key)
        {
            TEntity m = await _dbSet.FindAsync(key);
            if (m == null)
            {
                throw new KeyNotFoundException(string.Format("Key {0} not Found",key[0]));
            }
            _dbSet.Remove(m);
            try
            {
                await _uow.SaveAllChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ForegroundColor = ConsoleColor.Black;
                throw new Exception("خطای سیستمی", innerException: ex);
            }
        }

        public async Task<bool> DeleteAsync(TEntity model, bool saveNow)
        {
            _dbSet.Remove(model);
            if (saveNow)
            {
                try
                {
                    await _uow.SaveAllChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("خطای سیستمی", innerException: ex);
                }
            }
            return true;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity newModel, params object[] key)
        {
            var oldModel = await _dbSet.FindAsync(key);
            if (oldModel == null)
                throw new KeyNotFoundException(string.Format("Key {0} not Found", key[0]));
            _dbSet.Update(oldModel);

            try
            {
                await _uow.SaveAllChangesAsync();
                return newModel;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ForegroundColor = ConsoleColor.Black;
                throw new Exception("خطای سیستمی", innerException: ex);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity model, bool saveNow)
        {
            _dbSet.Update(model);
            if (saveNow)
            {
                try
                {
                    await _uow.SaveAllChangesAsync();
                    return model;
                }
                catch (Exception ex)
                {
                    throw new Exception("خطای سیستمی", innerException: ex);
                }
            }
            return model;
        }

        public Task<TEntity> FindAsync(params object[] key)
        {
            return _dbSet.FindAsync(key).AsTask();
        }

        public Task<TEntity> FindAsyncAsNoTracking(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.AsNoTracking().SingleOrDefaultAsync(expression);
        }

        public async Task<List<TEntity>> InsertRangeAsync(List<TEntity> list, bool saveNow)
        {
            _dbSet.AddRange(list);
            if (saveNow)
            {
                try
                {
                    await _uow.SaveAllChangesAsync();
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("خطای سیستمی", innerException: ex);
                }
            }
            return list;
        }

        public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> list, bool saveNow)
        {
            _dbSet.UpdateRange(list);
            if (saveNow)
            {
                try
                {
                    await _uow.SaveAllChangesAsync();
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("خطای سیستمی", innerException: ex);
                }
            }
            return list;
        }

        public async Task<bool> DeleteRangeAsync(List<TEntity> list, bool saveNow)
        {
            _dbSet.RemoveRange(list);
            if (saveNow)
            {
                try
                {
                    await _uow.SaveAllChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("خطای سیستمی", innerException: ex);
                }
            }
            return true;
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            try
            {
                await _uow.SaveAllChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("خطای سیستمی", innerException: ex);
            }
        }

        public TEntity Find(params object[] key)
        {
            return _dbSet.Find(key);
        }

        public async Task<int> GetMaxKeyAsync(Expression<Func<TEntity, int>> keySelector)
        {
            int x;
            try
            {
                x = await _dbSet.MaxAsync(keySelector);
            }
            catch (Exception)
            {
                x = 0;
            }
            return x;
        }

        public async Task<long> GetMaxKeyAsync(Expression<Func<TEntity, long>> keySelector)
        {
            long x;
            try
            {
                x = await _dbSet.MaxAsync(keySelector);
            }
            catch (Exception)
            {
                x = 0;
            }
            return x;
        }
    }
}
