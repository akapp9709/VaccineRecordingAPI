using Microsoft.EntityFrameworkCore;
using VaccineRecording.Data.Repositories.Interfaces;

namespace VaccineRecording.Data.Repositories
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected TContext _context;

        protected Repository(TContext context)
        {
            _context = context;
        }
        public void Delete(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
            _context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Insert(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            _context.SaveChanges();
        }

        public TEntity? GetSingle<TKey>(TKey itemId)
        {
            return _context.Set<TEntity>().Find(itemId);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
