using System;
using System.Collections.Generic;
using System.Text;

public class GameCharacter
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;

    public GameCharacter(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public event Action OnDeath;
    public event Action<int> OnDamaged;
    public event Action<int, string> OnAttack;

    public void TakeDamage(int damage)
    {
        OnDamaged?.Invoke(damage);

        if (Health <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void DoAttack(string name, int damage)
    {
        OnAttack?.Invoke(damage, name);
    }
}