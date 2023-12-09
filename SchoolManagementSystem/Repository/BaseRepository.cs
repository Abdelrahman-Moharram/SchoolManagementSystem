using SchoolManagementSystem.Data;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>  where T : class
    {
        private readonly ApplicationDbContext context;
        public BaseRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<List<T>> GetAll()
        {

           return await Task.FromResult(context.Set<T>().ToList());
        }

        public async Task<T> GetById(string id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> FindAll(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(context.Set<T>().Where(expression).ToList());
        }
        public async void Add(T t)
        {
            await context.Set<T>().AddAsync(t);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
