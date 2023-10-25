using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Данные о продажах за пять последних месяцев
        double[] sales = { 100, 120, 130, 150, 160 };

        // Создание массива номеров месяцев
        double[] months = Enumerable.Range(1, 5).Select(x => (double)x).ToArray();

        // Прогнозируемые месяцы
        double[] forecastMonths = { 6, 7, 8 };

        // Вычисление коэффициентов линейной регрессии (a и b) с использованием метода наименьших квадратов
        double n = months.Length;
        double sumX = months.Sum();
        double sumY = sales.Sum();
        double sumXY = Enumerable.Range(0, months.Length).Select(i => months[i] * sales[i]).Sum();
        double sumXSquare = Enumerable.Range(0, months.Length).Select(i => months[i] * months[i]).Sum();

        double a = (n * sumXY - sumX * sumY) / (n * sumXSquare - sumX * sumX);
        double b = (sumY - a * sumX) / n;

        // Прогнозирование объемов продаж на следующие три месяца
        double[] forecastedSales = new double[forecastMonths.Length];
        for (int i = 0; i < forecastMonths.Length; i++)
        {
            forecastedSales[i] = a * forecastMonths[i] + b;
        }

        Console.WriteLine("Прогноз объемов продаж на следующие три месяца:");
        for (int i = 0; i < forecastMonths.Length; i++)
        {
            Console.WriteLine($"Месяц {forecastMonths[i]}: {forecastedSales[i]:0.00}");
        }
    }
}
