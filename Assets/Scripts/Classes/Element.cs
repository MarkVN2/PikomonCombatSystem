using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Element
{
    private string name;
    public string Name { get => name; set => name = value; }
    private IElement type;
    public IElement Type { get => type; set => type = value; }

    private List<IElement> weaknesses;
    public List<IElement> Weaknesses { get => weaknesses; set => weaknesses = value; }

    private List<IElement> resistances;
    public List<IElement> Resistances { get => resistances; set => resistances = value; }

    private List<IElement> strengths;
    public List<IElement> Strengths { get => strengths; set => strengths = value; }
    public bool CheckWeaknessAgainst(Element element)
    {
        foreach (var weakness in Weaknesses)
        {
            if (weakness == element.Type)
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckResistanceAgainst(Element element)
    {
        foreach (var resistance in Resistances)
        {
            if (resistance == element.Type)
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckStrengthAgainst(Element element)
    {
        foreach (var strength in Strengths)
        {
            if (strength == element.Type)
            {
                return true;
            }
        }
        return false;
    }
}
