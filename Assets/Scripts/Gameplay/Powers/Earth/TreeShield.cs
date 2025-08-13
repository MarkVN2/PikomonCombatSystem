using UnityEngine;

public class TreeShield : Power
{
    public TreeShield()
    {
        Name = "Tree Shield";
        Element = new Earth();
        DamageType = IDamageType.Physical;
        HitChance = 1.0f;
        MaxCharges = 3;
        CurrentCharges = 3;
    }

    public override void UsePower(Pikomon user, Pikomon target)
    {
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            int damage = (int)CalculateDamage(user, target);
            Debug.Log($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return;
            target.TakeDamage(damage);
            user.AddEffect(new WoodShield(user));
        }
    }
}
