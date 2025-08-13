
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

    public override void UsePower(Pikomon user, Pikomon target)
    {
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            if (!Hit()) return;
            Debug.Log($"{user.Name} uses {Name} on {user.Name}!");
            user.AddEffect(new Enraged(user));
            Debug.Log($"{Name} used on {target.Name}!");
            target.AddEffect(new Burn(target));
        }
        else
        {
            Debug.Log($"{Name} has no charges left.");
        }
    }
}