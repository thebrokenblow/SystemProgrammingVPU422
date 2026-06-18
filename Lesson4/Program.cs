ThreadPool.QueueUserWorkItem(_ => DoWork1());
ThreadPool.QueueUserWorkItem(_ => DoWork2());

for (int i = 0; i <= 1_000; i++)
{
    Console.WriteLine($"Выполняется главная нить: {i}");
}

void DoWork1()
{
    for (int i = 0; i <= 1_000; i++)
    {
        Console.WriteLine($"Выполняется дочерняя 1 нить: {i}");
    }
}

void DoWork2()
{
    for (int i = 0; i <= 1_000; i++)
    {
        Console.WriteLine($"Выполняется дочерняя 2 нить: {i}");
    }
}