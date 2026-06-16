const int countKernel = 20;
const long totalNumbers = 2_000_000_000L;
ulong countIterations = totalNumbers / countKernel;

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

Console.WriteLine(sum.ToString());


static void CalculateSum(ulong left, ulong right, int threadIndex, ulong[] result)
{
    ulong sum = 0;
    for (ulong i = left; i <= right; i++)
    {
        sum += i;
    }

    result[threadIndex] = sum;
}