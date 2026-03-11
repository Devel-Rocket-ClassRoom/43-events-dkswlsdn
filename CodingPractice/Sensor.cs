using System;
using System.Collections.Generic;
using System.Text;

public class Sensor
{
    public event Action<string> Alert;

    public void Detect(string message)
    {
        Console.WriteLine($"감지: {message}");
        Alert?.Invoke(message); 
    }
}