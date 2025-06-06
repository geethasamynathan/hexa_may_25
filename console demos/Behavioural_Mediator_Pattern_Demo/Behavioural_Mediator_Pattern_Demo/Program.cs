namespace Behavioural_Mediator_Pattern_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           IChatMediator chatRoom=new ChatRoom();
            User tom = new User("Tom", chatRoom);
            User pam = new User("Pam", chatRoom);
            User fransy = new User("Fransy", chatRoom);

            chatRoom.AddUser(tom);
            chatRoom.AddUser(pam);
            chatRoom.AddUser(fransy);
            tom.Send("Hello Everyone");
            pam.Send("Hey from Pam");

            Console.ReadLine();
        }
    }
}
