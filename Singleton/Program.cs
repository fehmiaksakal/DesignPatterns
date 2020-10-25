using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ProcessManager processManager = new ProcessManager(); Constructor Private olduğu için hata alırız.

            var processManager = ProcessManager.CreateAsSingleton();
            processManager.Insert();

            Console.ReadLine();
        }
    }

    public class ProcessManager
    {
        static ProcessManager _processManager;
        static object _lockObj = new object();
        private ProcessManager()// Constructor Private tanımlanmalı.
        {

        }

        public static ProcessManager CreateAsSingleton()
        {
            lock (_lockObj)//ThreadSafe durumu korundu
            {
                if (_processManager == null)
                {
                    _processManager = new ProcessManager();
                }
            }

            return _processManager;
        }

        public void Insert()
        {
            Console.WriteLine("Process Saved");
        }

    }
}
