using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Dysmon", menuName = "Pikomon/Wind/Dysmon")]
public class Dysmon : Pikomon
{
    public Dysmon()
    {
        InitializeDefaults();
    }
    protected override void InitializeDefaults()
    {
        Name = "Dysmon";
        Species = "Dysmon";
        Element = new Wind();
        Health = 60f;
        MaxHealth = Health;
        Height = 0.2f;
        Weight = 5f;
        Attack = 35f;
        Defense = 30f;
        Speed = 65f;
        SpiritualAttack = 40f;
        SpiritualDefense = 45f;
        Powers = new List<Power>
        {
            new Tornado(),
            new WindBash(),
            new WallOfFortune(),
            new Whirlwind()
        };
    }
    public static Dysmon CreateRuntimeDysmon(string customName)
    {
        return CreateRuntimePikomon<Dysmon>(customName);
    }
}