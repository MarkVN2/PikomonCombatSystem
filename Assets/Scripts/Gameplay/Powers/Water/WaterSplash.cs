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

    public override void UsePower(Pikomon user, Pikomon target)
    {
        if (CurrentCharges > 0)
        {
            float damage = CalculateDamage(user, target);
            Debug.Log($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return;
            target.TakeDamage(damage);
            Debug.Log($"{Name} used on {target.Name}!");
            CurrentCharges--;
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }   
}