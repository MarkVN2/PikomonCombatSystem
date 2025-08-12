
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

    public override void UsePower(Pikomon user, Pikomon target)
    {

        if (CurrentCharges > 0)
        {
            if (!Hit()) return;
            Debug.Log($"{Name} used on {user.Name}!");
            user.Powers.ForEach(p =>
            {
                if (p is not GodWill)
                {
                    p.AddCharge();
                }
            });
            Debug.Log($"{user.Name} has gained a charge for each of its powers.");
            CurrentCharges--;
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}