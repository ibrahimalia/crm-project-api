using Meta.IntroApp.Services.Utility.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Utility.Publisher
{
    public class NotificationPublisher 
    {
        public string Name { get; set; }

        public event EventHandler<NotificationArgument> Arguments ;

        public void Notify(string message, string title, string topic, Dictionary<string, string> data)
        {
            NotificationArgument argument = new NotificationArgument(message, title, topic, data);

            if (Arguments != null)
            {
                Arguments(this, argument);
            }
        }



    }
}
