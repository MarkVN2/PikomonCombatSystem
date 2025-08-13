using UnityEngine;

public class Scratch : Power
{
    public Scratch()
    {
        Name = "Scratch";
        Element = new Neutral();
        DamageType = IDamageType.Physical;
        HitChance = 0.9f;
    }

    public override BattleResult UsePower(Pikomon user, Pikomon target)
    {
        var result = new BattleResult(false);
        float damage = CalculateDamage(user, target);
        result.messages.Add($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
        if (!Hit()) return result;
        target.TakeDamage(damage);
        return result;
    }
}