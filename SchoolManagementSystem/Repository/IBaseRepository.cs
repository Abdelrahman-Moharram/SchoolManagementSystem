using System.Linq.Expressions;

namespace SchoolManagementSystem.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll();  
        Task<T> GetById(string id);
        Task<List<T>> FindAll(Expression<Func<T, bool>> expression);
    }
}
