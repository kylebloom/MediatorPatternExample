using MediatorNotificationSystemExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorNotificationSystemExample.Services
{
    public class DatabaseService : IDatabaseService
    {
        public void UpdateDatabase(string query)
        {
            // Implementation for updating database
            Console.WriteLine($"Executing query: {query}");
        }
    }
}
