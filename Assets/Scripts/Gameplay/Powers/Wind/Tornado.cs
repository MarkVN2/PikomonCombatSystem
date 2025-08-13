
using UnityEngine;

/// <para><strong>SPECIAL POWER</strong> </para>
public class Tornado : Power
{
    public Tornado()
    {
        Name = "Tornado";
        Element = new Wind();
        DamageType = IDamageType.Spiritual;
        HitChance = 0.85f;
        MaxCharges = 4;
        CurrentCharges = 4;
    }
    public override BattleResult UsePower(Pikomon user, Pikomon target)
    {
        var result = new BattleResult(false);
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            float damage = CalculateDamage(user, target);
            result.messages.Add($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return result;
            target.TakeDamage(damage);
            user.AddEffect(new Windy(user));
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }
}