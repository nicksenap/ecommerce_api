namespace ecommerce_api.Interfaces;

public interface IService<T>
{
    Task<T> GetByIdAsync(string id);
    Task UpdateAsync(T item);
    Task CreateAsync(T item);
    Task<IEnumerable<T>> GetAllAsync();
}