using System.Linq;
public class Task323
{
    public static async Task Main(string[] args)
    {
        int count = await SlowRange().CountAwaitAsync(
             async value =>
             {
                 await Task.Delay(10);
                 return value % 2 == 0;
             });
        Console.WriteLine(count.ToString());
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