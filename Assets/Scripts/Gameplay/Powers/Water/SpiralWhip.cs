
using UnityEngine;

public class SpiralWhip : Power
{
    public SpiralWhip()
    {
        Name = "Spiral Whip";
        Element = new Water();
        DamageType = IDamageType.Spiritual;
        HitChance = 0.85f;
        MaxCharges = 2;
        CurrentCharges = 2;
    }

    public override void UsePower(Pikomon user, Pikomon target)
    {
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            float damage = CalculateDamage(user, target);
            Debug.Log($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return;
            target.TakeDamage(damage);
            Debug.Log($"{Name} used on {target.Name}!");
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }   
}