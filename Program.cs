using MediatorNotificationSystemExample.Enums;
using MediatorNotificationSystemExample.Interfaces;
using MediatorNotificationSystemExample.Mediators;
using MediatorNotificationSystemExample.Services;
using MediatorNotificationSystemExample.Subscribers;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorNotificationSystemExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<INotificationMediator, NotificationMediator>()
                .AddSingleton<IEmailService, EmailService>()
                .AddSingleton<IDatabaseService, DatabaseService>()
                .BuildServiceProvider();

            var mediator = serviceProvider.GetService<INotificationMediator>();

            var maintenanceSubscriber1 = new AlertSubscriber("John");
            var maintenanceSubscriber2 = new AlertSubscriber("Alice");
            var assetStatusSubscriber1 = new StatusUpdateSubscriber("Bob");
            var userMessageSubscriber1 = new UserMessageSubscriber("Charlie");

            mediator.RegisterSubscriber(maintenanceSubscriber1, NotificationType.Alert);
            mediator.RegisterSubscriber(maintenanceSubscriber2, NotificationType.Alert);
            mediator.RegisterSubscriber(assetStatusSubscriber1, NotificationType.StatusUpdate);
            mediator.RegisterSubscriber(userMessageSubscriber1, NotificationType.UserMessage);

            mediator.SendNotification("Maintenance needed on Asset 123", NotificationType.Alert);
            mediator.SendNotification("Asset 456 status updated to 'Operational'", NotificationType.StatusUpdate);
            mediator.SendNotification("Welcome new user!", NotificationType.UserMessage);
        }
    }
}
