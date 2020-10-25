using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Farklı sistemlerin kendi sistemlerimize entegre edilmesi durumunda kendi sistemimizin bozulmadan farklı sistemin ise sanki kendi sistemimizmiş gibi davranmasıdır. Bir servisi direk olarak bir metodun içinde kullanırsak o servise bağımlı hale geliriz.

            ProductManager prManager = new ProductManager(new Log4NetAdapter());
            prManager.Save();
            Console.ReadLine();
        }
    }
    class ProductManager
    {
        ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("log");
            Console.WriteLine("Saved");
        }
    }
    interface ILogger
    {
        void Log(string message);
    }
    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0}", message);
        }
    }
    //From Nuget
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }


}
