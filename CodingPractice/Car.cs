using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public int Fuel = 50;

    public event EventHandler<FuelEventArgs> FuelLow;
    public event Action<int> FuelChanged;

    public void Drive()
    {
        if (Fuel <= 0)
        {
            Console.WriteLine("연료 없음! 운전 불가");
            return;
        }


        
        Fuel -= 10;
        Console.WriteLine($"운전 중... 연료: {Fuel}%");
        FuelChanged?.Invoke(Fuel);

        if (Fuel <= 20)
        {
            FuelLow?.Invoke(this, new FuelEventArgs(Fuel));
        }
    }
}

public class Dashboard
{
    public void PrintFuelGauge(int gauge)
    {
        Console.WriteLine($"[대시보드] 연료 게이지: {gauge}");
    }
}

public class FuelEventArgs : EventArgs
{
    public int Fuel;

    public FuelEventArgs(int fuel)
    {
        Fuel = fuel;
    }
}