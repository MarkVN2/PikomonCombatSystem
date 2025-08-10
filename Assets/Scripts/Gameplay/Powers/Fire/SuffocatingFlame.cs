
using UnityEngine;

/// <para><strong>SPECIAL POWER</strong> </para>
public class SuffocatingFlame : Power
{
    public SuffocatingFlame()
    {
        Name = "Suffocating Flame";
        Element = new Fire();
        DamageType = IDamageType.Physical;
        HitChance = 0.75f;
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
            target.takeDamage(damage);
            Debug.Log($"{Name} used on {target.Name}!");
            CurrentCharges--;
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}