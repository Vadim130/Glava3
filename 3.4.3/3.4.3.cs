using System.Runtime.CompilerServices;

public class Task343
{

    public static async Task Main(string[] args)
    {
            await ConsumeSequence(SlowRange());
        // Производит последовательность, которая замедляется
        // в процессе выполнения операции.
    }
    static async IAsyncEnumerable<int> SlowRange(
     [EnumeratorCancellation] CancellationToken token = default)
    {
        for (int i = 0; i != 10; ++i)
        {
            await Task.Delay(i * 100, token);
            yield return i;
        }
    }
    static async Task ConsumeSequence(IAsyncEnumerable<int> items)
    {
        using var cts = new CancellationTokenSource(500);
        CancellationToken token = cts.Token;
        await foreach (int result in items.WithCancellation(token))
        {
            Console.WriteLine(result);
        }
    }
}       