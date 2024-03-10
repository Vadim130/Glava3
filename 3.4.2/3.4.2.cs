using System.Runtime.CompilerServices;

public class Task323
{
    public static async Task Main(string[] args)
    {
        using var cts = new CancellationTokenSource(500);
        CancellationToken token = cts.Token;
        await foreach (int result in SlowRange(token))
        {
            Console.WriteLine(result);
        }
    }
    // Производит последовательность, которая замедляется
    // в процессе выполнения операции.
    static async IAsyncEnumerable<int> SlowRange(
     [EnumeratorCancellation] CancellationToken token = default)
    {
        for (int i = 0; i != 10; ++i)
        {
            await Task.Delay(i * 100, token);
            yield return i;
        }
    }
}