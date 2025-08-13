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

    public override void UsePower(Pikomon user, Pikomon target)
    {
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            if (!Hit()) return;
            Debug.Log($"{Name} used on {user.Name}!");
            user.AddEffect(new GodlyAccuracy(user));
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}