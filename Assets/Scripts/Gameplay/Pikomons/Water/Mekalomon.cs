using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Mekalomon", menuName = "Pikomon/Water/Mekalomon")]
public class Mekalomon : Pikomon
{
    public Mekalomon()
    {
        InitializeDefaults();
    }
    protected override void InitializeDefaults()
    {
        Name = "Mekalomon";
        Species = "Mekalomon";
        Element = new Water();
        Health = 200f;
        MaxHealth = Health;
        Height = 2.2f;
        Weight = 270f;
        Attack = 25f;
        Defense = 25f;
        Speed = 15f;
        SpiritualAttack = 40f;
        SpiritualDefense = 60f;
        Powers = new List<System.Type>
        {
            typeof(RejuvenscentWaters),
            typeof(RestoringFlame),
            typeof(WindBash),
            typeof(BloodManipulation)
        };
    }
    public static Mekalomon CreateRuntimeMekalomon(string customName)
    {
        return CreateRuntimePikomon<Mekalomon>(customName);
    }
}