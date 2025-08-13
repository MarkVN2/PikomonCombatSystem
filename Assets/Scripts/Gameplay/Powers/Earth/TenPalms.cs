
using UnityEngine;

public class TenPalms : Power
{
    public TenPalms()
    {
        Name = "Ten Palms";
        Element = new Earth();
        DamageType = IDamageType.Physical;
        HitChance = 0.75f;
        MaxCharges = 2;
        CurrentCharges = 2;
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
            result.hit = true;
            result.damage = damage;
            return result;
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }
}