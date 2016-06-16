using System;
using LogModule;
using LogModule.Loggers;

namespace LogExample
{
    public class Calculator
    {
        private readonly ILogger logger;

        public Calculator(ILogger logger)
        {
            this.logger = logger;

            logger.AddActionBefore(LogType.Info | LogType.Error, () => Console.WriteLine("Show this message before every INFO or ERROR log"));
        }

        public float Add(params float[] values)
        {
            float sum = 0;

            foreach (var v in values)
            {
                logger.Info(v);
                sum += v;
            }

            logger.Debug("Sum = " + sum);

            return sum;
        }

        public float Subtract(params float[] values)
        {
            float dif = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                float v = values[i];
                dif -= v;
            }

            return dif;
        }

        public float Multiply(params float[] values)
        {
            float prod = 1;

            foreach (var v in values)
            {
                prod *= v;
            }

            return prod;
        }

        public float Divide(params float[] values)
        {
            float quot = values[0];

            try
            {
                for (int i = 1; i < values.Length; i++)
                {
                    float v = values[i];
                    if (Math.Abs(v) < 0.001)
                    {
                        throw new DivideByZeroException();
                    }
                    quot /= v;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return quot;
        }
    }
}