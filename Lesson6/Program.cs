object locker = new();

int x = 0;

var threads = new Thread[5];

for (int i = 0; i < threads.Length; i++)
{
    var numberThread = i;
    threads[i] = new Thread(() => Print(numberThread));
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}

Console.WriteLine(x);

void Print(int numberThread)
{
    bool flagLock = false;
    Monitor.Enter(locker, ref flagLock);

    x = 0;
    for (int i = 0; i < 6; i++)
    {
        x++;
        Console.WriteLine($"выполняется нить: {numberThread}");
        Thread.Sleep(100);
    }

    Monitor.Exit(locker);
}