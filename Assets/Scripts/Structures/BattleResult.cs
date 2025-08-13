using System.Collections.Generic;

public struct BattleResult
{
    public bool hit;
    public float damage;
    public List<string> messages;
    
    public BattleResult(bool hit, float damage = 0f)
    {
        this.hit = hit;
        this.damage = damage;
        this.messages = new List<string>();
    }
}