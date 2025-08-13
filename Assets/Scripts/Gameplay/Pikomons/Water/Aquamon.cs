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
        Powers = new List<Power>
        {
            new RejuvenscentWaters(),
            new SpiralWhip(),
            new WaterSplash(),
            new BloodManipulation()
        };
    }
}