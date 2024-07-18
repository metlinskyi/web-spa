using TranslationManagement.Data.Management;

public interface INotification<T>
{
    Task Send(T value);
}