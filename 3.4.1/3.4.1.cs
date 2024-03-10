public class Task323
{
    public static async Task Main(string[] args)
    {
        await foreach (int result in SlowRange())
        {
            Console.WriteLine(result);
            if (result >= 8)
                break;
        }
    }
// Производит последовательность, которая замедляется
// в процессе выполнения операции.
    static async IAsyncEnumerable<int> SlowRange()
    {
        for (int i = 0; i != 10; ++i)
        {
            await Task.Delay(i * 100);
            yield return i;
        }
    }
}