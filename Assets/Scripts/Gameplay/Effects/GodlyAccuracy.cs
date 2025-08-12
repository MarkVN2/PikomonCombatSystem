using UnityEngine;

public class GodlyAccuracy : Effect
{
    public GodlyAccuracy(Pikomon target)
    {
        Name = "Godly Accuracy";
        Duration = 3; 
        Target = target;
    }
    public override void ApplyEffect()
    {
        Target.Powers.ForEach(p => p.HitChance += 0.20f);
    }

    public override void ProcessEffect()
    {
        Debug.Log($"{Name} is affecting {Target.Name}.");
        DurationTick();
    }
    
    
    public override void RemoveEffect()
    {
        Target.Powers.ForEach(p => p.HitChance -= 0.20f);
        Target.ActiveEffects.Remove(this);
        Debug.Log($"{Name} has worn off from {Target.Name}.");
    }
}