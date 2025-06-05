using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_OPen_Close_Demo
{
   public enum InvoiceType
    {
        ProposedInvoice,
        FinalInvoice
    }
    public class Invoice
    { 
        public  virtual double GetInvoiceDiscount(double amount)
        {
            return amount - 100;
        }
    }
    public class FinalInvoice : Invoice
    {
    public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount) - 200;
        }
    }
    public class ProposedInvoice : Invoice
    {

        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount)-50;
        }
    }

    public class RecurringInvoice : Invoice 
    {
        public override double GetInvoiceDiscount(double amount)
        {
            return base.GetInvoiceDiscount(amount)-300;
        }
    }


}
