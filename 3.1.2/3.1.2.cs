public class Task312
{
    public static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        var task = GetValuesAsync(client);
        await foreach (var value in task)
            Console.WriteLine("{0}", value);
    }

    static async IAsyncEnumerable<string> GetValuesAsync(HttpClient client)
    {
        int offset = 0;
        const int limit = 10;
        while (true)
        {
            // Получить текущую страницу результатов и разобрать их.
            string result = await client.GetStringAsync(
                $"https://example.com/api/values?offset={offset}&limit={limit}");
            string[] valuesOnThisPage = result.Split('\n');
            // Произвести результаты для этой страницы.
            foreach (string value in valuesOnThisPage)
                yield return value;
            // Если это последняя страница, работа закончена.
            if (valuesOnThisPage.Length != limit)
                break;
            // В противном случае перейти к следующей странице.
            offset += limit;
        }
    }
}