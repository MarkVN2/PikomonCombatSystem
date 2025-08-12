using UnityEngine;

public class WoodShield : Effect
{
    public WoodShield(Pikomon target)
    {
        Name = "Wood Shield";
        Duration = 3;
        Target = target;
    }
    public override void ApplyEffect()
    {
        Target.Defense += 10;
        Target.SpiritualDefense += 40;
    }

    public override void ProcessEffect()
    {

        Debug.Log($"{Name} is affecting {Target.Name}.");
        DurationTick();
    }
    
    
    public override void RemoveEffect()
    {
        Target.Defense -= 10;
        Target.SpiritualDefense -= 40;
        Target.ActiveEffects.Remove(this);
    }
}