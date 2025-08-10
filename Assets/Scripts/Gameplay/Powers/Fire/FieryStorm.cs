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

    public override void UsePower(Pikomon user,Pikomon target)
    {

        if (CurrentCharges > 0)
        {
            float damage = CalculateDamage(user, target) + 10;
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
