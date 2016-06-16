using System;
using LogModule;
using LogModule.Loggers;
using LogModule.Loggers.TraceLogger;

namespace LogExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = LoggerFactory.Create<TraceLogger>();
            
            Calculator calculator = new Calculator(logger);
            calculator.Add(5, 2, 6);
            calculator.Multiply(4, 5, 3);
            calculator.Divide(1, 5, 0);

            Console.ReadKey();
        }
    }
}
