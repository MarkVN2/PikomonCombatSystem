
using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "New Pikomonomon", menuName = "Pikomon/Fire/Pikomonomon")]
public class Pikomonomon : Pikomon
{
    public Pikomonomon()
    {
        InitializeDefaults();
    }
    protected override void InitializeDefaults()
    {
        Name = "Pikomonomon";
        Species = "Pikomonomon";
        Element = new Fire();
        Health = 150f;
        MaxHealth = 150f;
        Height = 0.7f;
        Weight = 25f;
        Attack = 25f;
        Defense = 60f;
        Speed = 50f;
        SpiritualAttack = 50f;
        SpiritualDefense = 40f;
        Powers = new List<Power>
        {
            new FieryStorm(),
            new Gamble(),
            new Scorching(),
            new GodWill(),
            new Scratch()
        };
    }
}