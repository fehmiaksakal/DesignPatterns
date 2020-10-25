using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            // or u can use  CustomerManager manager = new CustomerManager(new ProcessFactory());
            CustomerManager manager = new CustomerManager(new BadProcessFactory());
            manager.Save();
            Console.ReadLine();
        }
    }
    public class ProcessFactory : IProcessFactory
    {
        public IProcess CreateProcess()
        {
            return new TmProcess();
        }
    }
    public class BadProcessFactory : IProcessFactory
    {
        public IProcess CreateProcess()
        {
            return new BadProcess();
        }
    }
    public interface IProcess
    {
        void Process();
    }
    public interface IProcessFactory
    {
        IProcess CreateProcess();
    }
    public class TmProcess : IProcess
    {
        public void Process()
        {
            Console.WriteLine("Tm Process");
        }
    }
    public class BadProcess : IProcess
    {
        public void Process()
        {
            Console.WriteLine("Bad Process");
        }
    }
    public class CustomerManager
    {
        private readonly IProcessFactory _processFactory;
        public CustomerManager(IProcessFactory processFactory)
        {
            _processFactory = processFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            IProcess process = _processFactory.CreateProcess();
            process.Process();
        }
    }
}
