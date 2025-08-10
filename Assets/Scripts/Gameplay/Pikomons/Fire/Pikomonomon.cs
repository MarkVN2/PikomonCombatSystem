
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
        MaxHealth = Health;
        Height = 0.7f;
        Weight = 25f;
        Attack = 25f;
        Defense = 60f;
        Speed = 50f;
        SpiritualAttack = 50f;
        SpiritualDefense = 40f;
        Powers = new List<System.Type>
        {
            typeof(FieryStorm),
            typeof(Gamble),
            typeof(Scorching),
            typeof(GodWill)
        };
    }
    public static Pikomonomon CreateRuntimePikomonomon(string customName)
    {
        return CreateRuntimePikomon<Pikomonomon>(customName);
    }
}