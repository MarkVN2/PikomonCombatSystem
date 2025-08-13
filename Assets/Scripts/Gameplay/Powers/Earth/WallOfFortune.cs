using System.Linq;
using UnityEngine;

/// <para><strong>SPECIAL POWER</strong> </para>
public class WallOfFortune : Power
{

    public WallOfFortune()
    {
        Name = "Wall of Fortune";
        Element = new Earth();
        HitChance = 1f;
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
            user.AddEffect(new GodlyAccuracy(user));
            result.messages.Add($"{user.Name} gains Godly Accuracy for the next turn!");
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }
}