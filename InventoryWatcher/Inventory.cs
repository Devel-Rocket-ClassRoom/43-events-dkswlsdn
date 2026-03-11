using System;
using System.Collections.Generic;
using System.Text;

public class Inventory
{
    public event Action<string, int, int> ItemChanged;

    public Dictionary<string, int> Items = new Dictionary<string, int>();

    public void AddItem(string name, int count)
    {
        if (!Items.ContainsKey(name))
            Items.Add(name, 0);

        int oldCount = Items[name];

        Items[name] += count;

        ItemChanged?.Invoke(name, oldCount, Items[name]);
    }

    public void RemoveItem(string name, int count)
    {
        if (Items.ContainsKey(name))
        {
            int oldCount = Items[name];

            if (Items[name] - count < 0)
            {
                count = Items[name];
            }

            Items[name] -= count;

            ItemChanged?.Invoke(name, oldCount, Items[name]);

        }
    }
}

public class InventoryUI
{
    public void PrintChangeLog(string name, int oldCount, int newCount)
    {
        Console.WriteLine($"[UI] {name}: {oldCount} → {newCount}");
    }
}

public class AutoBuyer
{
    public void AutoBuy(string name, int oldCount, int newCount)
    {
        if (newCount <= 0)
        {
            Console.WriteLine($"[자동구매] {name} 재고 소진! 자동 구매 요청");
        }
    }
}