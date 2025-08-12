
using UnityEngine;
/// <summary>
/// A  Wind-type physical attack that strikes with compressed air bursts.
/// This versatile power has moderate accuracy but can be used multiple times per battle.
/// </summary>
/// <remarks>
/// Wind Bash is a reliable offensive power that:
/// - Deals physical damage using concentrated wind pressure
/// - Has moderate accuracy (45% hit chance) due to wind's unpredictable nature
/// - Can be used frequently (6 charges per battle)
/// - Balances lower accuracy with higher usage frequency
/// </remarks>
public class WindBash : Power
{
    public WindBash()
    {
        Name = "Wind Bash";
        Element = new Wind();
        DamageType = IDamageType.Physical;
        HitChance = 0.45f;
        MaxCharges = 6;
        CurrentCharges = 6;
          
    }

    public override void UsePower(Pikomon user,Pikomon target)
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