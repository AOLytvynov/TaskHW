Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Демонстрація шаблону Composite:\n");

var circle1 = new Circle("Червоне коло");
var square1 = new Square("Синій квадрат");

var group1 = new GraphicGroup("Група 1");
group1.Add(circle1);
group1.Add(square1);

var group2 = new GraphicGroup("Група 2");
group2.Add(new Circle("Зелене коло"));
group2.Add(group1);

group2.Draw();

// Абстрактний компонент
public abstract class Graphic
{
    public string Name { get; set; }

    public Graphic(string name)
    {
        Name = name;
    }

    // Метод, який мають реалізувати всі компоненти
    public abstract void Draw(int indent = 0);
}

// Лист — простий об'єкт (не має підоб'єктів)
public class Circle : Graphic
{
    public Circle(string name) : base(name) { }

    public override void Draw(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"Коло: {Name}");
    }
}

public class Square : Graphic
{
    public Square(string name) : base(name) { }

    public override void Draw(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"Квадрат: {Name}");
    }
}

// Composite — контейнер для графічних об'єктів
public class GraphicGroup : Graphic
{
    private List<Graphic> _children = new();

    public GraphicGroup(string name) : base(name) { }

    public void Add(Graphic graphic)
    {
        _children.Add(graphic);
    }

    public void Remove(Graphic graphic)
    {
        _children.Remove(graphic);
    }

    public override void Draw(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"Група: {Name}");
        foreach (var child in _children)
        {
            child.Draw(indent + 2); // малюємо дочірні з відступом
        }
    }
}

