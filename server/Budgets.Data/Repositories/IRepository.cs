public interface IRepository<T>
{
    IEnumerable<T> List();
    T GetById(int id);
    T Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}