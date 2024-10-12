namespace TranslationManagement.Notifications;

using External.ThirdParty.Services;
using Microsoft.Extensions.DependencyInjection;
using Api.Notifications;
using Data.Management;

internal static class Extensions
{
    public static IServiceCollection AddNotifications(this IServiceCollection services)
    {
        services.AddTransient<INotificationService, UnreliableNotificationService>();
        services.AddTransient<INotification<JobRecrod>, JobNotification>();

        return services;
    }
}