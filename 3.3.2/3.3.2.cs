using System.Linq;
public class Task323
{
    public static async Task Main(string[] args)
    {
        IAsyncEnumerable<int> values = SlowRange().Where(
     value => value % 2 == 0);
        await foreach (int result in values)
        {
            Console.WriteLine(result);
        }
    }
    static async IAsyncEnumerable<int> SlowRange()
    {
        for (int i = 0; i != 10; ++i)
        {
            await Task.Delay(i * 100);
            yield return i;
        }
    }
}