using UnityEngine;

public class Whirlwind : Power
{
    public Whirlwind()
    {
        Name = "Whirlwind";
        Element = new Wind();
        DamageType = IDamageType.Physical;
        HitChance = 0.8f;
        MaxCharges = 3;
        CurrentCharges = 3;
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
            result.messages.Add($"{Name} used on {target.Name}!");
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }
}