namespace RegistrationAndLogin.Interfaces
{
    public interface IRepo<K, T> : IBaseRepo<K, T>
    {
        T Update(T item);
        T Delete(K key);
    }
}
