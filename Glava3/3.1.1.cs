public class Task311
{

    public static async Task Main(string[] args)
    {
        var task = GetValuesAsync();
        await foreach (var value in task)
            Console.WriteLine("{0}", value);
    }

    static async IAsyncEnumerable<int> GetValuesAsync()
    {
        await Task.Delay(1000); // Асинхронная работа
        yield return 10;
        await Task.Delay(1000); // Другая асинхронная работа
        yield return 13;
    }
}
