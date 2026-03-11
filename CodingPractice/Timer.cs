using System;
using System.Collections.Generic;
using System.Text;

public class Timer
{
    public event Action Tick;
    private int _tick = 1;

    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"타이머: {_tick++}초");
            Tick?.Invoke();
        }
    }
}

public class Logger
{
    public void Log()
    {
        Console.WriteLine("[Logger] 틱 기록됨");
    }
}