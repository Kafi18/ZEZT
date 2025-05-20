using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Калькулятор\n===========\nДоступные операции:\n1. Сложение (+)\n2. Вычитание (-)\n3. Умножение (*)\n4. Деление (/)\n5. Остаток (%)\n6. Инкремент (++)\n7. Декремент (--)\n");

        var op = GetOperation();
        double a = GetNumber("Введите число: "), b = op < 6 ? GetNumber("Введите второе число: ") : 0;

        try
        {
            Console.WriteLine($"\nРезультат: {Calculate(op, a, b)}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("\nОшибка: деление на ноль!");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    static int GetOperation()
    {
        while (true)
        {
            Console.Write("Выберите операцию (номер или символ): ");
            string input = Console.ReadLine().Trim().ToLower();

            switch (input)
            {
                case "1": case "+": case "add": return 1;
                case "2": case "-": case "subtract": return 2;
                case "3": case "*": case "multiply": return 3;
                case "4": case "/": case "divide": return 4;
                case "5": case "%": case "modulo": return 5;
                case "6": case "++": case "increment": return 6;
                case "7": case "--": case "decrement": return 7;
                default: Console.WriteLine("Неверная операция!"); break;
            }
        }
    }

    static double GetNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double num)) return num;
            Console.WriteLine("Некорректное число!");
        }
    }

    static double Calculate(int op, double a, double b) => op switch
    {
        1 => a + b,
        2 => a - b,
        3 => a * b,
        4 when b == 0 => throw new DivideByZeroException(),
        4 => a / b,
        5 => a % b,
        6 => a + 1,
        7 => a - 1,
        _ => throw new InvalidOperationException()
    };
}