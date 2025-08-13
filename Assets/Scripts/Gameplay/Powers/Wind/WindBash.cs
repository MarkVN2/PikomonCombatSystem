
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

    public override BattleResult UsePower(Pikomon user,Pikomon target)
    {
        var result = new BattleResult(false);
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            float damage = CalculateDamage(user, target);
            result.messages.Add($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return result;
            target.TakeDamage(damage);
            result.messages.Add($"{Name} used on {target.Name}!");
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }
}