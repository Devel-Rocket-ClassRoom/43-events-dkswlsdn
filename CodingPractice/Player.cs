using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    public int Health { get; set; } = 100;

    public event Action<int> DamageTaken;

    public void TakeDamage(int damage)
    {
        DamageTaken?.Invoke(damage);
    }
}

public class HealthBar
{
    public void OnPlayerDamaged(int currentHealth)
    {
        Console.WriteLine($"[UI] 체력바 업데이트: {currentHealth}%");
    }
}

public class SoundManager
{
    public void OnPlayerDamaged(int currentHealth)
    {
        Console.WriteLine("[Sound] 피격 효과음 재생");
    }
}