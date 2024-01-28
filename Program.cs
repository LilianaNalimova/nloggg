using System;
using NLog;

public class Program
{
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите число:");
            int num = int.Parse(Console.ReadLine());

            ExampleClass example = new ExampleClass();
            example.MultiplyInfiniteLoop(num);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Произошла ошибка: {0}", ex.Message);
        }
    }


    public class ExampleClass
    {
        public void MultiplyInfiniteLoop(int num)
        {
            try
            {
                while (true)
                {
                    checked
                    {
                        num *= num;
                    }
                }
            }
            catch (OverflowException ex)
            {
                logger.Error(ex, "Произошло переполнение при умножении {0} в бесконечном цикле", num);
                throw;
            }
        }
    }
}