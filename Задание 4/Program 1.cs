using System;

class DepositCalculator
{
    static void Main()
    {
        decimal sum = ReadDecimal("Введите сумму вклада: ");
        int months = ReadInt("Введите количество месяцев: ");

        for (int i = 0; i < months; i++)
            sum *= 1.07m;

        Console.WriteLine($"Конечная сумма вклада: {sum:F2}");
    }

    static decimal ReadDecimal(string prompt)
    {
        Console.Write(prompt);
        return decimal.Parse(Console.ReadLine());
    }

    static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.Parse(Console.ReadLine());
    }
}