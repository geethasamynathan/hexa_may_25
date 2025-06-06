using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioural_Chain_Of_Responsibility_Demo
{
    public abstract class SupportHandler
    {
        protected SupportHandler nextHandler;

        public void SetNext(SupportHandler next)
        {
            nextHandler = next;
        }
        public abstract void HandleRequest(string issueType);
    }
    public class Level1Support : SupportHandler
    {
        public override void HandleRequest(string issueType)
        {
            if(issueType=="password reset")
            {
                Console.WriteLine("Level 1 Supprot Handled to reset the Password"); ;
            }
            else if(nextHandler!=null)
            {
                nextHandler.HandleRequest(issueType);
            }
        }
    }
    public class Level2Support : SupportHandler
    {
        public override void HandleRequest(string issueType)
        {
            if (issueType == "software issue")
            {
                Console.WriteLine("Level 2 Supprot  working on fixing the bug"); ;
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleRequest(issueType);
            }
        }
    }
    public class ManagerSupport : SupportHandler
    {
        public override void HandleRequest(string issueType)
        {
                Console.WriteLine($"Manager, Handling the {issueType}"); 
        }
    }
}
