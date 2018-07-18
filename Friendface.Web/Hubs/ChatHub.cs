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
            if (messages.Count > 0)
            {
                var lastMessage = messages[messages.Count - 1].Content;
                Clients.Caller.SendAsync(lastMessage);               
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
