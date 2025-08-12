
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

    public override void UsePower(Pikomon user, Pikomon target)
    {
        if (CurrentCharges > 0)
        {
            Debug.Log($"{Name} used on {user.Name}!");
            if (!Hit()) return;
            target.AddEffect(new Burn(target));
            CurrentCharges--;
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}