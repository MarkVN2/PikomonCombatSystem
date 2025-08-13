using UnityEngine;

/// <summary>
/// <para><strong>SPECIAL POWER</strong> </para>
/// A supportive Fire-type power that restores health to the user.
/// </summary>
public class RestoringFlame : Power
{
    public RestoringFlame()
    {
        Name = "Restoring Flame";
        Element = new Fire();
        DamageType = IDamageType.Spiritual;
        HitChance = 1f;
        MaxCharges = 2;
        CurrentCharges = 2;
    }
    public override BattleResult UsePower(Pikomon user, Pikomon target)
    {
        var result = new BattleResult(false);   
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            result.messages.Add($"{Name} used on {target.Name}!");
            if (!Hit()) return result;
            user.Heal(20f);
            result.messages.Add($"{user.Name} has been healed by 20 points.");
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }
}