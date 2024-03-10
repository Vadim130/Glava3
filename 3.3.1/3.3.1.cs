using System.Linq;
public class Task322{

    public static async Task Main(string[] args)
    {

        IAsyncEnumerable<int> values = SlowRange().WhereAwait(
            async value =>
            {
                // Выполнить некоторую асинхронную работу для определения
                // того, должен ли элемент быть включен в результат.
                await Task.Delay(10);
                return value % 2 == 0;
            });
        await foreach (int result in values)
        {
            Console.WriteLine(result);
        }
        // Производит последовательность, которая замедляется
        // в процессе выполнения операции.

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