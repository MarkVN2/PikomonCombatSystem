using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Rokumon", menuName = "Pikomon/Earth/Rokumon")]
public class Rokumon : Pikomon
{
    public Rokumon()
    {
        InitializeDefaults();
    }
    protected override void InitializeDefaults()
    {
        Name = "Rokumon";
        Species = "Rokumon";
        Element = new Earth();
        Health = 65f;
        MaxHealth = Health;
        Height = 1.2f;
        Weight = 70f;
        Attack = 60f;
        Defense = 55f;
        Speed = 35f;
        SpiritualAttack = 60f;
        SpiritualDefense = 50f;
        Powers = new List<Power>
        {
            new TenPalms(),
            new EnragedInferno(),
            new Scorching(),
            new BulletBarrage()
        };
    }
    public static Rokumon CreateRuntimeRokumon(string customName)
    {
        return CreateRuntimePikomon<Rokumon>(customName);
    }
}