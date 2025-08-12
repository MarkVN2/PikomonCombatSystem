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
        Health = 100;
        MaxHealth = 100;
        Attack = 50;
        Defense = 50;
        Speed = 30;
        SpiritualAttack = 40;
        SpiritualDefense = 40;
        Powers = new List<Power>
        {
            new TreeShield(),
            new Gamble(),
            new RejuvenscentWaters(),
            new BulletBarrage()
        };
    }
}