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
    public override BattleResult UsePower(Pikomon user,Pikomon target)
    {
        BattleResult result = new BattleResult(false);
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            float damage = CalculateDamage(user, target) + ADDITIONAL_DAMAGE;
            result.messages.Add($"{user.Name} uses {Name} on {target.Name} for {damage} damage!");
            if (!Hit()) return result;
            target.TakeDamage(damage);
            result.messages.Add($"{Name} used on {target.Name}!");
        }
        else
        {
            result.messages.Add($"{Name} is out of charges!");
        }
        return result;
    }
}