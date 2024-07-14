using MediatorNotificationSystemExample.Enums;
using MediatorNotificationSystemExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorNotificationSystemExample.Mediators
{
    public interface INotificationMediator
    {
        void SendNotification(string message, NotificationType type);
        void RegisterSubscriber(INotificationSubscriber subscriber, NotificationType type);
        void UnregisterSubscriber(INotificationSubscriber subscriber, NotificationType type);
    }
}
