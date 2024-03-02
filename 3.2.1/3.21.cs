public class Task321
{
    string name;
    public Task321(string title)
    {
        name = title;
    }

    public static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        Task321 t = new Task321("Groot test");
        await t.ProcessValueAsync(client);
    }
    async IAsyncEnumerable<string> GetValuesAsync(HttpClient client)
    {
        yield return "Hello";
        await Task.Delay(1000);
        yield return "World";
        await Task.Delay(1000);
        yield return "I am Groot!";
        await Task.Delay(1000);
        yield return name + " done!";
    }
    public async Task ProcessValueAsync(HttpClient client)
    {
        await foreach (string value in GetValuesAsync(client))
        {
            Console.WriteLine(value);
        }
    }
}