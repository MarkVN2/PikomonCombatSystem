using UnityEngine;
using System.Collections.Generic;

public class Wind : Element
{
    public Wind()
    {
        Name = "Wind";
        Type = IElement.Wind;
        Weaknesses = new List<IElement> { IElement.Earth };
        Resistances = new List<IElement> { IElement.Water };
        Strengths = new List<IElement> { IElement.Fire };
    }
}
