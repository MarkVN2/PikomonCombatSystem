using UnityEngine;

public class Burn : Effect
{
    public Burn(Pikomon target)
    {
        Name = "Burn";
        Duration = 2;
        Target = target;
    }
    public override void ApplyEffect()
    {
    }

    public override void ProcessEffect()
    {
        Target.TakeDamage(10);
        Debug.Log($"{Name} is affecting {Target.Name}.");
        DurationTick();
    }
    
    
    public override void RemoveEffect()
    {
        Target.ActiveEffects.Remove(this);
    }
}