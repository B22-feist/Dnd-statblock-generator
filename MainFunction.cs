using System;
class Program
{
    static void Main()
    {
        StatBlock s = new StatBlock();
        
        s.Health = -1;
        Console.Write(s.Health);
    }
}

class StatBlock
{
    private int _health;
    public int Health{
        get => _health;
        set {
            if (value < 0)
            {
                Health = 1;
            }
        }
    }
}