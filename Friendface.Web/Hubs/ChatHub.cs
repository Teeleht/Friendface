using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendface.Web.Hubs
{
    public class ChatHub: Hub
    {
        private static List<Message> messages = new List<Message>();
        public async Task SendMessage(string message)
        {
            string username = Context.User.Identity.Name;
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            Message newMessage = new Message
            {
                Username = username,
                Time = time,
                Content = message,
            };
            messages.Add(newMessage);

            await Clients.All.SendAsync("ReceiveMessage", username, message, time);
        }

        public override Task OnConnectedAsync()
        {
            if (messages.Count > 0 && messages.Count < 5)
            {
                for (int i = 1; i <= messages.Count; i++)
                {
                    var lastMessage = messages[messages.Count - i];
                    Clients.Caller.SendAsync("ReceiveMessage", lastMessage.Username, lastMessage.Content, lastMessage.Time);
                }             
            }
            else if (messages.Count > 0 && messages.Count >= 5)
            {
                for (int i = 1; i <= 5; i++)
                {
                    var lastMessage = messages[messages.Count - i];
                    Clients.Caller.SendAsync("ReceiveMessage", lastMessage.Username, lastMessage.Content, lastMessage.Time);
                }
            }
            return base.OnConnectedAsync();
        }
    }

    public class Message
    {
        public string Username { get; set; }
        public string Time { get; set; }
        public string Content { get; set; }
    }
}
