using UnityEngine;
/// <summary>
/// <para><strong>SPECIAL POWER</strong> </para>
/// A vampiric Water-type power that deals physical damage and heals the user for half the damage dealt.
/// This life-draining ability allows the user to sustain themselves while weakening their opponent.
/// </summary>
/// <remarks>
/// Blood Manipulation is a balanced offensive/defensive power that:
/// - Deals physical damage based on the user's Attack stat
/// - Heals the user for 50% of the damage dealt
/// - Has moderate accuracy (70% hit chance)
/// - Limited to 2 uses per battle
/// </remarks>

public class BloodManipulation : Power
{
    public BloodManipulation()
    {
        Name = "Blood Manipulation";
        Element = new Water();
        DamageType = IDamageType.Physical;
        HitChance = 0.70f;
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
            user.Heal(damage * 0.5f);
            Debug.Log($"{user.Name} heals for {damage * 0.5f} health!");
            Debug.Log($"{Name} used on {target.Name}!");
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}