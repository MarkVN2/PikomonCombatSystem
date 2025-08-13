using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Himon", menuName = "Pikomon/Fire/Himon")]
public class Himon : Pikomon
{

    public Himon()
    {
        InitializeDefaults();
    }
    protected override void InitializeDefaults()
    {
        Name = "Himon";
        Species = "Himon";
        Element = new Fire();
        Health = 100f;
        MaxHealth = Health;
        Height = 1.5f;
        Weight = 50f;
        Attack = 30f;
        Defense = 20f;
        Speed = 25f;
        SpiritualAttack = 40f;
        SpiritualDefense = 30f;
        Powers = new List<Power>
        {
            new FieryStorm(),
            new RestoringFlame(),
            new Scorching(),
            new TenPalms(),
        };
    }
}