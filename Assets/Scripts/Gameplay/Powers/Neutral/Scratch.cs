using UnityEngine;

public class Scratch : Power
{
    public Scratch()
    {
        Name = "Scratch";
        Element = new Neutral();
        DamageType = IDamageType.Physical;
        HitChance = 0.9f;
    }

    public override void UsePower(Pikomon user, Pikomon target)
    {
            float damage = CalculateDamage(user, target);
            Debug.Log($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return;
            target.TakeDamage(damage);
            Debug.Log($"{Name} used on {target.Name}!");
    }
}