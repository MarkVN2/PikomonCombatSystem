using System.Collections.Generic;

public class Neutral : Element
{
    public Neutral()
    {
        Name = "Neutral";
        Type = IElement.Neutral;
        Weaknesses = new List<IElement> {  };
        Resistances = new List<IElement> {  };
        Strengths = new List<IElement> {  };
    }
}