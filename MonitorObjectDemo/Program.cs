Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Демонстрація шаблону Monitor Object:\n");

Counter counter = new Counter();

// Створюємо 3 потоки, які одночасно інкрементують лічильник
Thread thread1 = new Thread(() => counter.Increment("Потік 1"));
Thread thread2 = new Thread(() => counter.Increment("Потік 2"));
Thread thread3 = new Thread(() => counter.Increment("Потік 3"));

thread1.Start();
thread2.Start();
thread3.Start();

thread1.Join();
thread2.Join();
thread3.Join();

// Monitor Object — інкапсулює синхронізований доступ
public class Counter
{
    private int _count = 0;
    private readonly object _lock = new();

    public void Increment(string threadName)
    {
        lock (_lock) // Синхронізований доступ
        {
            Console.WriteLine($"{threadName} → Збільшує лічильник...");
            int temp = _count;
            Thread.Sleep(100); // Емуляція навантаження
            _count = temp + 1;
            Console.WriteLine($"{threadName} → Поточне значення: {_count}");
        }
    }
}
