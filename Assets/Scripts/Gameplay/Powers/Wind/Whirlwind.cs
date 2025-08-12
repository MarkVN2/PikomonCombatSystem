using UnityEngine;

public class Whirlwind : Power
{
    public Whirlwind()
    {
        Name = "Whirlwind";
        Element = new Wind();
        DamageType = IDamageType.Physical;
        HitChance = 0.8f;
        MaxCharges = 3;
        CurrentCharges = 3;
    }

    public override void UsePower(Pikomon user, Pikomon target)
    {
        if (CurrentCharges > 0)
        {
            float damage = CalculateDamage(user, target);
            Debug.Log($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return;
            target.TakeDamage(damage);
            Debug.Log($"{Name} used on {target.Name}!");
            CurrentCharges--;
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}