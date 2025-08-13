
using UnityEngine;
/// <summary>
/// <para><strong>SPECIAL POWER</strong> </para>
/// A high-risk, high-reward Earth-type power that deals damage based on the target's current health.
/// Has only 50% hit chance but can deal up to 70% of the target's health as damage.
/// </summary>
/// <remarks>
/// This power is designed as a gamble - it has a low hit chance but potentially devastating damage.
/// The damage scales with the target's current health, making it more effective against healthy opponents.
/// </remarks>
public class Gamble : Power
{
    public Gamble()
    {
        Name = "Gamble";
        Element = new Earth();
        DamageType = IDamageType.Physical;
        HitChance = 0.5f; 
        MaxCharges = 1; 
        CurrentCharges = 1;
    }

    public override BattleResult UsePower(Pikomon user, Pikomon target)
    {
        var result = new BattleResult(false);
        if (CurrentCharges > 0)
        {
            // Special Ability: Gamble deals damage based on the target's health
            CurrentCharges--;
            BaseDamage = target.Health * Random.Range(0.0f, 0.7f);
            float damage = CalculateDamage(user, target);
            if (!Hit())
            {
                result.messages.Add($"Good Luck next time {user.Name}!");
                return result;
            }
            target.TakeDamage(damage);
            result.hit = true;
            result.damage = damage;
            result.messages.Add($"{Name} used on {target.Name}!");
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
        return result;
    }
}