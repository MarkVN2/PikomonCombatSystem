using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Aquamon", menuName = "Pikomon/Water/Aquamon")]
public class Aquamon : Pikomon
{
    public Aquamon()
    {
        InitializeDefaults();
    }
    protected override void InitializeDefaults()
    {
        Name = "Aquamon";
        Species = "Aquamon";
        Element = new Water(); 
        Health = 90f;
        MaxHealth = Health;
        Height = 1.2f;
        Weight = 30f;
        Attack = 25f;
        Defense = 30f;
        Speed = 35f;
        SpiritualAttack = 40f;
        SpiritualDefense = 45f;
        Powers = new List<System.Type>
        {
            typeof(RejuvenscentWaters),
            typeof(SpiralWhip),
            typeof(WaterSplash),
            typeof(BloodManipulation)
        };
    }

    public static Aquamon CreateRuntimeAquamon(string customName)
    {
        return CreateRuntimePikomon<Aquamon>(customName);
    }
}