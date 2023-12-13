using System.Linq.Expressions;

namespace SchoolManagementSystem.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();  
        List<T> GetAll();
        Task<T> GetById(string id);
        Task<List<T>> FindAll(Expression<Func<T, bool>> expression);
        void Add(T t);
        void update(T t);
        void Save();
        void SaveAsync();
        Task<int> GetCount();
        Task<T> Find(Expression<Func<T, bool>> expression);
    }
}
