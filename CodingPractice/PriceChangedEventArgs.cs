using System;
using System.Collections.Generic;
using System.Text;

public class PriceChangedEventArgs : EventArgs
{
    public double OldPrice;
    public double NewPrice;
    public double ChangePercent;

    public PriceChangedEventArgs(double oldPrice, double newPrice)
    {
        OldPrice = oldPrice;
        NewPrice = newPrice;
        ChangePercent = (newPrice - oldPrice) / oldPrice * 100;
    }
}

public class Stock
{
    public string Name;
    public double Price;

    public event EventHandler<PriceChangedEventArgs> PriceChanged;

    public void ChangePrice(double newPrice)
    {
        PriceChanged?.Invoke(this, new PriceChangedEventArgs(Price, newPrice));
        Price = newPrice;
    }
}