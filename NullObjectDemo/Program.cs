Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Демонстрація шаблону Null Object:\n");

// Реальний логер
ILogger realLogger = new ConsoleLogger();
var serviceWithLogger = new UserService(realLogger);
serviceWithLogger.CreateUser("Олексій");

Console.WriteLine();

// Null-об'єкт замість null
ILogger nullLogger = new NullLogger();
var serviceWithoutLogging = new UserService(nullLogger);
serviceWithoutLogging.CreateUser("Гість");

// Абстрактний інтерфейс або базовий клас
public interface ILogger
{
    void Log(string message);
}

// Реальна реалізація логера
public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}

// Null Object — нічого не робить, але реалізує інтерфейс
public class NullLogger : ILogger
{
    public void Log(string message)
    {
        // Нічого не робить
    }
}

// Клас, який залежить від логера, але не перевіряє на null
public class UserService
{
    private readonly ILogger _logger;

    public UserService(ILogger logger)
    {
        _logger = logger;
    }

    public void CreateUser(string name)
    {
        Console.WriteLine($"Створено користувача: {name}");
        _logger.Log($"Користувача '{name}' створено.");
    }
}

