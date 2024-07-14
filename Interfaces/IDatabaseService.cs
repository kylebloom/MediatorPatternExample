using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorNotificationSystemExample.Interfaces
{
    public interface IDatabaseService
    {
        void UpdateDatabase(string query);
    }
}
