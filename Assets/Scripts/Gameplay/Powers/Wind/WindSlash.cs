
using UnityEngine;
/// <summary>
/// A precise Wind-type physical attack that creates razor-sharp wind blades to slash enemies.
/// This focused power has higher accuracy than Wind Bash but fewer uses per battle.
/// </summary>
/// <remarks>
/// Wind Slash is a precision offensive power that:
/// - Deals physical damage using sharp, cutting wind currents
/// - Has good accuracy (60% hit chance) due to focused wind control
/// - Limited to moderate usage (3 charges per battle)
/// - Balances higher accuracy with lower usage frequency compared to Wind Bash
/// </remarks>
public class WindSlash : Power
{
    public WindSlash()
    {
        Name = "Wind Slash";
        Element = new Wind();
        DamageType = IDamageType.Physical;
        HitChance = 0.60f;
        MaxCharges = 3;
        CurrentCharges = 3;
    }

    public override void UsePower(Pikomon user,Pikomon target)
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