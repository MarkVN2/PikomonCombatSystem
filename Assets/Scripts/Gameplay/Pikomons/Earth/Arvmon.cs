using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Arvmon", menuName = "Pikomon/Earth/Arvmon  ")]
public class Arvmon : Pikomon
{
    public Arvmon()
    {
        InitializeDefaults();
    }
    protected override void InitializeDefaults()
    {
        Name = "Arvmon";
        Species = "Arvmon";
        Element = new Earth();
        Health = 100f;
        MaxHealth = 100f;
        Weight = 50f;
        Height = 3f;
        Attack = 50f;
        Defense = 50f;
        Speed = 30f;
        SpiritualAttack = 40f;
        SpiritualDefense = 40f;
        Powers = new List<Power>
        {
            new TreeShield(),
            new Gamble(),
            new RejuvenscentWaters(),
            new BulletBarrage(),
            new Scratch()
        };
    }
}