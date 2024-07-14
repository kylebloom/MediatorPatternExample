using MediatorNotificationSystemExample.Enums;
using MediatorNotificationSystemExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorNotificationSystemExample.Subscribers
{
    public class StatusUpdateSubscriber(string name) : INotificationSubscriber
    {
        private readonly string _name = name;

        public void ReceiveNotification(string message, NotificationType type)
        {
            if (type == NotificationType.StatusUpdate)
            {
                Console.WriteLine($"Status Update Subscriber {_name} received: {message}");
            }
        }
    }
}
