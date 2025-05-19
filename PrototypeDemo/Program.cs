using System;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Демонстрація шаблону Prototype:\n");

// Створюємо оригінальний об'єкт
User originalUser = new User { Name = "Олена", Age = 30 };
Console.WriteLine("Оригінал:");
originalUser.Display();

// Клонуємо об'єкт
User clonedUser = (User)originalUser.Clone();
clonedUser.Name = "Марія"; // Змінюємо ім'я в копії

Console.WriteLine("\nКопія:");
clonedUser.Display();

Console.WriteLine("\nПеревірка, оригінального об'єкту:");
originalUser.Display();

public interface IPrototype
{
    IPrototype Clone();
}

// Конкретна реалізація прототипу — клас користувача
public class User : IPrototype
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Метод, який створює копію об'єкта
    public IPrototype Clone()
    {
        return new User
        {
            Name = this.Name,
            Age = this.Age
        };
    }

    public void Display()
    {
        Console.WriteLine($"Ім'я: {Name}, Вік: {Age}");
    }
}