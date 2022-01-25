using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Utility.EventArguments
{
    public class NotificationArgument : EventArgs
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Topic { get; set; }
        public Dictionary<string,string> Data { get; set; }


        public NotificationArgument(string Message , string Title, string Topic, Dictionary<string, string> Data)
        {
            this.Message = Message;
            this.Topic = Topic;
            this.Data = Data;
            this.Title = Title;
        }
    }
}
