using System;
class P
{
    static void Main()
    {
        for (int i = 1; i <= 10; Console.WriteLine(), i++)
            for (int j = 1; j <= 10; Console.Write($"{i * j}\t"), j++) ;
    }
}