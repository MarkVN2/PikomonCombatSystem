
using UnityEngine;

public class EnragedInferno : Power
{
    public EnragedInferno()
    {
        Name = "Enraged Inferno";
        Element = new Fire();
        HitChance = 1.0f;
        CurrentCharges = 1;
        MaxCharges = 1;
    }

    public override BattleResult UsePower(Pikomon user, Pikomon target)
    {
        var result = new BattleResult(false);
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            if (!Hit()) return result;
            result.messages.Add($"{user.Name} uses {Name} on {user.Name}!");
            user.AddEffect(new Enraged(user));
            result.messages.Add($"{Name} used on {target.Name}!");
            target.AddEffect(new Burn(target));
        }
        else
        {
            result.messages.Add($"{Name} has no charges left.");
        }
        return result;
    }
}