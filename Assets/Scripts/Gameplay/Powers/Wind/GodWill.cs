
using UnityEngine;

/// <para><strong>SPECIAL POWER</strong> </para>
public class GodWill : Power
{
    public GodWill()
    {
        Name = "God Will";
        Element = new Earth();
        HitChance = 0.90f;
        MaxCharges = 1;
        CurrentCharges = 1;
    }

    public override BattleResult UsePower(Pikomon user, Pikomon target)
    {
        var result = new BattleResult(false);
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            if (!Hit()) return result;
            result.messages.Add($"{Name} used on {user.Name}!");
            user.Powers.ForEach(p =>
            {
                if (p is not GodWill)
                {
                    p.AddCharge();
                }
            });
            result.messages.Add($"{user.Name} has gained a charge for each of its powers.");
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }
}