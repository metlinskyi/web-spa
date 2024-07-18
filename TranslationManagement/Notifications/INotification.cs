public interface INotification<T>
{
    Task Send(T value);
}