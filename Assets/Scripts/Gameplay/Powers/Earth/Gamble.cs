
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

    public override void UsePower(Pikomon user, Pikomon target)
    {
        if (CurrentCharges > 0)
        {
            // Special Ability: Gamble deals damage based on the target's health
            BaseDamage = target.Health * Random.Range(0.0f, 0.7f); 
            float damage = CalculateDamage(user, target);
            Debug.Log($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit())
            {
                Debug.Log("Good Luck next time");
                return;
            }
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