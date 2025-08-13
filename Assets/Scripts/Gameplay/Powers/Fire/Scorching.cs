
using UnityEngine;

public class Scorching : Power
{
    public Scorching()
    {
        Name = "Scorching";
        Element = new Fire();
        DamageType = IDamageType.Spiritual;
        HitChance = 0.65f;
        MaxCharges = 3;
        CurrentCharges = 3;
    }

    public override BattleResult UsePower(Pikomon user, Pikomon target)
    {
        var result = new BattleResult(false);
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            result.messages.Add($"{Name} used on {user.Name}!");
            if (!Hit()) return result;
            target.AddEffect(new Burn(target));
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }
}