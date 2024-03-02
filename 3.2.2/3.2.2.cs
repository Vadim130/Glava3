using System.Xml.Linq;

public class Task322
{

    public static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        await ProcessValueAsync(client);

    }
    static async IAsyncEnumerable<string> GetValuesAsync(HttpClient client)
    {
        yield return "Hello";
        await Task.Delay(1000);
        yield return "World";
        await Task.Delay(1000);
        yield return "I am Groot!";
    }
    public static async Task ProcessValueAsync(HttpClient client)
    {
        await foreach (string value in GetValuesAsync(client))
        {
            await Task.Delay(100); // асинхронная работа
            Console.WriteLine(value);
        }
    }
}