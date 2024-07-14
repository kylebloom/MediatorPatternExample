using MediatorNotificationSystemExample.Enums;
using MediatorNotificationSystemExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorNotificationSystemExample.Mediators
{
    public class NotificationMediator : INotificationMediator
    {
        private readonly IEmailService _emailService;
        private readonly IDatabaseService _databaseService;
        private readonly Dictionary<NotificationType, List<INotificationSubscriber>> _subscribers;

        public NotificationMediator(IEmailService emailService, IDatabaseService databaseService)
        {
            _emailService = emailService;
            _databaseService = databaseService;
           _subscribers = new Dictionary<NotificationType, List<INotificationSubscriber>>();
            foreach (NotificationType type in Enum.GetValues(typeof(NotificationType)))
            {
                _subscribers[type] = [];
            }
        }

        public void SendNotification(string message, NotificationType type)
        {
            foreach (var subscriber in _subscribers[type])
            {
                subscriber.ReceiveNotification(message, type);
            }

            // Example of triggering resource access based on notification type
            if (type == NotificationType.Alert)
            {
                _emailService.SendEmail("maintenance@example.com", "Maintenance Alert", message);
                _databaseService.UpdateDatabase("UPDATE Maintenance SET Status='Alerted' WHERE Message='" + message + "'");
            }
        }

        public void RegisterSubscriber(INotificationSubscriber subscriber, NotificationType type)
        {
            if (!_subscribers[type].Contains(subscriber))
            {
                _subscribers[type].Add(subscriber);
            }
        }

        public void UnregisterSubscriber(INotificationSubscriber subscriber, NotificationType type)
        {
            if (_subscribers[type].Contains(subscriber))
            {
                _subscribers[type].Remove(subscriber);
            }
        }
    }
}
