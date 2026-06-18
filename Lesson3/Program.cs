using System.Diagnostics;

public class Program
{
    private const int countKernel = 20;

    public static void Main()
    {
        ulong div = 2;
        ulong number = 6_000_000_000L;

        ulong myResult = number * (number + 1) / div;
        Console.WriteLine(myResult);

        Stopwatch stopwatch = Stopwatch.StartNew();

        ulong mySum = 0;
        for (ulong i = 1; i <= number; i++)
        {
            mySum += i;
        }

        stopwatch.Stop();

        // Retrieve results using different properties
        TimeSpan ts = stopwatch.Elapsed;
        long ms = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Total Time: {ts}");
        Console.WriteLine($"Milliseconds: {ms} ms");

        Console.WriteLine(mySum);

        stopwatch = Stopwatch.StartNew();

        ulong countIterations = number / countKernel;

        var result = new ulong[countKernel];
        var threads = new Thread[countKernel];

        for (int i = 0; i < countKernel; i++)
        {
            ulong left = 1 + countIterations * (ulong)i;
            ulong right = countIterations * ((ulong)i + 1);

            int threadIndex = i;

            threads[i] = new Thread(() => CalculateSum(left, right, threadIndex, result));
        }

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Start();
        }

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join();
        }

        ulong sum = 0;
        for (int i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        stopwatch.Stop();

        ts = stopwatch.Elapsed;
        ms = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Total Time: {ts}");
        Console.WriteLine($"Milliseconds: {ms} ms");

        Console.WriteLine(sum.ToString());
    }

    //1..200_000_000
    //200_000_001..400_000_00
    //
    static void CalculateSum(ulong left, ulong right, int threadIndex, ulong[] result)
    {
        ulong sum = 0;
        for (ulong i = left; i <= right; i++)
        {
            sum += i;
        }

        result[threadIndex] = sum;
    }
}