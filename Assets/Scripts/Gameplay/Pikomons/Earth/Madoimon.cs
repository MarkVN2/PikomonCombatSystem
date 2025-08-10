using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Madoimon", menuName = "Pikomon/Earth/Madoimon")]
public class Madoimon : Pikomon
{
    public Madoimon()
    {
        InitializeDefaults();
    }
    protected override void InitializeDefaults()
    {
        Name = "Madoi";
        Species = "Madoimon";
        Element = new Earth();
        Health = 155f;
        MaxHealth = Health;
        Height = 1.6f;
        Weight = 60f;
        Attack = 50f;
        Defense = 15f;
        Speed = 100f;
        SpiritualAttack = 5f;
        SpiritualDefense = 0f;
        Powers = new List<System.Type>
        {
            typeof(BulletBarrage),
            typeof(WallOfFortune),
            typeof(WindBash),
            typeof(TenPalms)
        };
    }
    public static Madoimon CreateRuntimeMadoimon(string customName)
    {
        return CreateRuntimePikomon<Madoimon>(customName);
    }
}