using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тумаков_упр_6._3
{ 

    class Program
    {
        static void Main()
        {
            const int months = 12;
            const int days = 30;

            Random rnd = new Random();

            // Двумерный массив температур: [месяц, день]
            // Диапазон: от -20 до +35 °C
            int[,] temperature = new int[months, days];
            for (int m = 0; m < months; m++)
                for (int d = 0; d < days; d++)
                    temperature[m, d] = rnd.Next(-20, 36); // 36 — верхняя граница не включается

            // Печать исходных температур по месяцам
            Console.WriteLine("Температуры по месяцам:");
            PrintTemperatures(temperature);

            // Получаем массив средних температур (по одному значению на месяц)
            double[] averages = GetMonthlyAverages(temperature);

            Console.WriteLine("\nСредняя температура по месяцам:");
            string[] monthNames =
            {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            };
            for (int m = 0; m < months; m++)
                Console.WriteLine($"{monthNames[m],-10}: {averages[m],6:F2} °C");

            // Сортировка массива средних температур по возрастанию
            double[] sorted = (double[])averages.Clone();
            Array.Sort(sorted);

            Console.WriteLine("\nСредние температуры, отсортированные по возрастанию:");
            for (int i = 0; i < sorted.Length; i++)
                Console.WriteLine($"{i + 1,2}. {sorted[i],6:F2} °C");
        }
        static double[] GetMonthlyAverages(int[,] temperature)
        {
            int months = temperature.GetLength(0);
            int days = temperature.GetLength(1);

            double[] averages = new double[months];

            for (int m = 0; m < months; m++)
            {
                double sum = 0;
                for (int d = 0; d < days; d++)
                    sum += temperature[m, d];

                averages[m] = sum / days;
            }

            return averages;
        }
        static void PrintTemperatures(int[,] temperature)
        {
            int months = temperature.GetLength(0);
            int days = temperature.GetLength(1);

            for (int m = 0; m < months; m++)
            {
                Console.Write($"Месяц {m + 1,2}: ");
                for (int d = 0; d < days; d++)
                    Console.Write($"{temperature[m, d],4}");
                Console.WriteLine();
            }
        }
    }





































}
