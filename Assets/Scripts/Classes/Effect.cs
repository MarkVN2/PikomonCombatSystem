using UnityEngine;

public abstract class Effect
{
    private int duration;
    private string name;
    private Pikomon target;
    public Pikomon Target { get { return target; } set { target = value; } }
    public string Name { get { return name; } set { name = value; } }
    public int Duration { get { return duration; } set { duration = value; } }

    public abstract void ApplyEffect();
    public abstract void RemoveEffect();
    public abstract void ProcessEffect();

    public void DurationTick()
    {
        Duration--;
        if (Duration <= 0)
        {
            Debug.Log($"{Name} has worn off from {Target.Name}.");
            RemoveEffect();
        }
    }
}