using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPDemo
{
    internal class MailSender
    {
        public string EmailFrom { get; set; }
        public int EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public void SendEmail() {

            Console.WriteLine("Mail sending ");
        }
    }
}
