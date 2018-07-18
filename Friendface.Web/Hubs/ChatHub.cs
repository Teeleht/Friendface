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
            var username = Context.User.Identity.Name;
            var time = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            var newMessage = new Message
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
            var lastMessages = messages.OrderByDescending(x => x.Time).Take(5).ToList().OrderBy(x => x.Time);

            foreach (var message in lastMessages)
            {
                Clients.Caller.SendAsync("ReceiveMessage", message.Username, message.Content, message.Time);
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
