using UnityEngine;

public class WaterSplash : Power
{
    public WaterSplash()
    {
        Name = "Water Splash";
        Element = new Water();
        DamageType = IDamageType.Spiritual;
        HitChance = 0.7f;
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
            result.messages.Add($"{Name} used on {target.Name}!");
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }   
}