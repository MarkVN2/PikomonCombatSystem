using System.Collections.Generic;
using UnityEngine;

public class Earth : Element
{
    public Earth()
    {
        Name = "Earth";
        Type = IElement.Earth;
        Weaknesses = new List<IElement> { IElement.Fire };
        Resistances = new List<IElement> { };
        Strengths = new List<IElement> { IElement.Wind };
    }
}
