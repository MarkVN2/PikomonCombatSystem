using UnityEngine;

public class BulletBarrage : Power
{
    public const float ADDITIONAL_DAMAGE = 5f;
    public BulletBarrage()
    {
        Name = "Bullet Barrage";
        Element = new Earth();
        DamageType = IDamageType.Physical;
        HitChance = 0.35f;
        MaxCharges = 10;
        CurrentCharges = 10;
    }
    public override void UsePower(Pikomon user,Pikomon target)
    {

        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            float damage = CalculateDamage(user, target) + ADDITIONAL_DAMAGE;
            Debug.Log($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return;
            target.TakeDamage(damage);
            Debug.Log($"{Name} used on {target.Name}!");
        }
        else
        {
            Debug.Log($"{Name} is out of charges!");
        }
    }
}