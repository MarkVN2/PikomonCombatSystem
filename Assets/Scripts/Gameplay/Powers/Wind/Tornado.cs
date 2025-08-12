
using UnityEngine;

/// <para><strong>SPECIAL POWER</strong> </para>
public class Tornado : Power
{
    public Tornado()
    {
        Name = "Tornado";
        Element = new Wind();
        DamageType = IDamageType.Spiritual;
        HitChance = 0.85f;
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
            user.AddEffect(new Windy(user));
            CurrentCharges--;
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}