using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioural_Mediator_Pattern_Demo
{
    public interface IChatMediator
    {
        void SendMessage(string message,User user);
        void AddUser(User user);
    }

    public class User
    {
        public string Name { get; }
        private IChatMediator chatMediator;
        public User(string name, IChatMediator chatMediator)
        {
            Name = name;
            this.chatMediator = chatMediator;
        }

        public void Send(string message)
        {
            Console.WriteLine($"{Name} sends: {message}");
            chatMediator.SendMessage(message,this);
        }

        public void Receive(string message,string from)
        {
            Console.WriteLine($"{Name} receives from {from}: {message}");

        }
    }

    public class ChatRoom : IChatMediator
    {
     private List<User> users=new List<User>();
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void SendMessage(string message,User sender) {
            foreach (var user in users)
            {
                if (user != sender)
                {
                    user.Receive(message, sender.Name);
                }
            }
        }
    }



}
