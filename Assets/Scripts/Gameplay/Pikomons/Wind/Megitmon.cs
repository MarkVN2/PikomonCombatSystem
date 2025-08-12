using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Megitmon", menuName = "Pikomon/Wind/Megitmon")]
public class Megitmon : Pikomon
{
    public Megitmon()
    {
        InitializeDefaults();
    }
    protected override void InitializeDefaults()
    {
        Name = "Megitmon";
        Species = "Megitmon";
        Element = new Wind();
        Health = 110f;
        MaxHealth = Health;
        Height = 1f;
        Weight = 54f;
        Attack = 40f;
        Defense = 60f;
        Speed = 40f;
        SpiritualAttack = 40f;
        SpiritualDefense = 60f;
        Powers = new List<Power>
        {
            new WindSlash(),
            new Scorching(),
            new Tornado(),
            new Scratch()
        };
    }
    public static Megitmon CreateRuntimeMegitmon(string customName)
    {
        return CreateRuntimePikomon<Megitmon>(customName);
    }
}   