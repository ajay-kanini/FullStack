namespace TicketGeneration.Interfaces
{
    public interface IRepo<T, K>
    {
        Task<T?> Add(T item);
        Task<T?> Update(T item);
        Task<T?> Delete(K key);
        Task<T?> GetByInternId(K key);
        Task<T?> GetByTicketId(K key);
        Task<ICollection<T>> GetAll();
    }
}
