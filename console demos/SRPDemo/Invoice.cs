using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SRPDemo
{

   

    internal class Invoice
    {
        public long InvoiceAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public void AddInvoice()
        {
            Console.WriteLine("Invoice Added");
            MailSender mailSender = new MailSender();
            mailSender.SendEmail();
               // MailMessage mailMessage = new MailMessage("EmailFrom", "EmailTo", "Subject", "Invoice Added");
           
        }
        public void RemoveInvoice()
        {          
                Console.WriteLine("Invoice Removed");
          
        }

      
        //public void SendInvoiceMail(MailMessage mailMessage)
        //{
        //    Console.WriteLine("Email sent");
       // }

    }
}
