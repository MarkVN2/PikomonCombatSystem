using System.Collections.Generic;
using UnityEngine;

public class Water : Element
{
    public Water()
    {
        Name = "Water";
        Type = IElement.Water;
        Weaknesses = new List<IElement> { IElement.Wind };
        Resistances = new List<IElement> {  };
        Strengths = new List<IElement> { IElement.Earth };
    }
}
