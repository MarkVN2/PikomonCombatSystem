
using UnityEngine;

public class Enraged : Effect
{
    public Enraged(Pikomon target)
    {
        Name = "Enraged";
        Duration = 3; 
        Target = target;
    }

    public override void ApplyEffect()
    {
        Target.Attack += 10; 
        Debug.Log($"{Name} has been applied to {Target.Name}.");
    }

    public override void ProcessEffect()
    {
        Debug.Log($"{Name} is affecting {Target.Name}. Attack increased to {Target.Attack}.");
        DurationTick();
    }

    public override void RemoveEffect()
    {
        Target.Attack -= 10; 
        Target.ActiveEffects.Remove(this);
    }
}