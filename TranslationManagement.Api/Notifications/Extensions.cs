namespace TranslationManagement.Notifications;

using External.ThirdParty.Services;
using Microsoft.Extensions.DependencyInjection;
using Api.Notifications;
using Data.Management;

internal static class Extensions
{
    public static IServiceCollection AddNotifications(this IServiceCollection _)
    {
        return _ 
                .AddTransient<INotificationService, UnreliableNotificationService>()
                .AddTransient<INotification<JobRecrod>, JobNotification>()
                ;
    }
}