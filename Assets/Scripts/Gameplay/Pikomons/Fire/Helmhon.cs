using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Helmhon", menuName = "Pikomon/Fire/Helmhon")]
public class Helmhon : Pikomon
{
    protected override void InitializeDefaults()
    {
        Name = "Helmhon";
        Species = "Helmhon";
        Element = new Fire();
        Health = 120f;
        MaxHealth = Health;
        Height = 1.0f;
        Weight = 46f;
        Attack = 45f;
        Defense = 35f;
        Speed = 86f;
        SpiritualAttack = 55f;
        SpiritualDefense = 40f;
        Powers = new List<Power>
        {
            new FieryStorm(),
            new RestoringFlame(),
            new Scorching(),
            new EnragedInferno()
        };
    }

    public static Helmhon CreateRuntimeHelmhon(string customName)
    {
        return CreateRuntimePikomon<Helmhon>(customName);
    }
}