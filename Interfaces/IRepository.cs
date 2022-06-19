namespace ecommerce_api.Interfaces;

public interface IRepository<T>
{
    //Retrieves list of items in table
    Task<IEnumerable<T>> GetAsync();
    //Creates from detached item
    Task UpdateAsync(T item);
    Task CreateAsync(T item);
    Task<bool> DeleteAsync(string id);
    Task<T> GetAsync(string id);
}