using System;
using System.Collections.Generic;

namespace SigmaHT_3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWorker fileworker = new FileWorker(@"C:\Users\User\source\repos\SigmaHT_3\SigmaHT_3\InputFile.txt");

            ElectricityAccounting electricityAccounting;

            try
            {
                electricityAccounting = fileworker.GetElectricityAccounting();
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            Console.WriteLine(electricityAccounting.GetReport());

            Console.WriteLine("Enter number of flat to want to get information:");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(electricityAccounting.GetReportByNumber(number));

            Console.Write("Surname of owner with the largest debt: ");
            Console.WriteLine(electricityAccounting.GetTheMosetDebtedOwner());

            Console.Write("Number of flat with no electricity consumption: ");
            Console.WriteLine(electricityAccounting.GetFlatNumberWithNoConsumption());

            Console.WriteLine("Enter size of square matrix:");

            int size = int.Parse(Console.ReadLine());

            MagicSquare magicSquare;

            try
            {
                magicSquare = new MagicSquare(size);
                magicSquare.GenerateMagicSquare();

            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            Console.WriteLine("Magic Square:\n"+magicSquare);

        }
        
    }
    
}

