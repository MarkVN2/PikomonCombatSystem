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
    public override void UsePower(Pikomon user, Pikomon target)
    {
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            Debug.Log($"{Name} used on {target.Name}!");
            if (!Hit()) return;
            user.Heal(20f);
            Debug.Log($"{user.Name} has been healed by 20 points.");
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}