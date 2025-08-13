using UnityEngine; 

public class FieryStorm : Power
{
    public FieryStorm()
    {
        Name = "Fiery Storm";
        Element = new Fire();
        DamageType = IDamageType.Spiritual;
        HitChance = 0.40f;
        MaxCharges = 5; 
        CurrentCharges = 5;
    }

    public override BattleResult UsePower(Pikomon user,Pikomon target)
    {
        var result = new BattleResult(false);
        if (CurrentCharges > 0)
        {
            CurrentCharges--;
            float damage = CalculateDamage(user, target) + 10;
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
