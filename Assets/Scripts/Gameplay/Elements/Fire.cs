using UnityEngine;
using System.Collections.Generic;
public class Fire : Element
{
    public Fire()
    {
        Name = "Fire";
        Type = IElement.Fire;
        Weaknesses = new List<IElement> { IElement.Water };
        Resistances = new List<IElement> { };
        Strengths = new List<IElement> { IElement.Earth };
    }
}
