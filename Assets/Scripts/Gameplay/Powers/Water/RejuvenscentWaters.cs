using UnityEngine;
/// <summary>
/// <para><strong>SPECIAL POWER</strong> </para>
/// A supportive Water-type power that restores health to the user through rejuvenating waters.
/// This healing ability restores 50-70% of the user's current health with guaranteed success.
/// </summary>
/// <remarks>
/// Rejuvenscent Waters is a powerful self-healing ability that:
/// - Restores 50-70% of the user's current health (random within range)
/// - Has guaranteed success (never misses)
/// - Limited to 1 use per battle
/// - Cannot heal beyond maximum health
/// </remarks>
public class RejuvenscentWaters : Power
{
    private const float MIN_HEAL_PERCENTAGE = 0.5f;
    private const float MAX_HEAL_PERCENTAGE = 0.7f;

    public RejuvenscentWaters()
    {
        Name = "Rejuvenscent Waters";
        Element = new Water();
        DamageType = IDamageType.Spiritual;
        HitChance = 1f;
        MaxCharges = 1;
        CurrentCharges = 1;
    }

    public override BattleResult UsePower(Pikomon user, Pikomon target)
    {
        var result = new BattleResult(false);
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            float healPercentage = Random.Range(MIN_HEAL_PERCENTAGE, MAX_HEAL_PERCENTAGE);
            float healAmount = user.Health * healPercentage;

            if (!Hit())
            {
                result.messages.Add($"{Name} mysteriously failed to activate!"); // Or is it
                return result;
            }
            result.messages.Add($"{Name} used on {target.Name}!");
            user.Heal(healAmount);
            result.messages.Add($"{user.Name} has been healed by {healAmount} points.");
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }

}