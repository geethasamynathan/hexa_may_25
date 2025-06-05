using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Singleton_Demo
{
    public class Configuration
    {
        private static Configuration _instance;
        private static readonly object _instanceLock = new object();
        public  string Setting { get; private set; }
        public Configuration() {
            Console.WriteLine("Configuration Loaded");
        }

        public static Configuration Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if(_instance == null)
                    {
                        _instance = new Configuration();
                    }
                }
                return _instance;
            }
        }

    }
}
