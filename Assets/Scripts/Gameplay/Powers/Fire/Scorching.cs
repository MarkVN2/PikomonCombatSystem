
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
            float damage = CalculateDamage(user, target);
            Debug.Log($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return;
            target.takeDamage(damage);
            Debug.Log($"{Name} used on {target.Name}!");
            CurrentCharges--;
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}