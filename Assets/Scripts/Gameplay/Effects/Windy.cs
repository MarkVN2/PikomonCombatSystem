using UnityEngine;

public class Windy : Effect
{
    public Windy(Pikomon target)
    {
        Name = "Windy";
        Duration = 4;
        Target = target;
    }
    public override void ApplyEffect()
    {
        Target.Speed += 60;
    }

    public override void ProcessEffect()
    {

        Debug.Log($"{Name} is affecting {Target.Name}.");
        DurationTick();
    }
    
    
    public override void RemoveEffect()
    {
        Target.Speed -= 60;
        Target.ActiveEffects.Remove(this);
    }
}