using UnityEngine;

[System.Serializable]
public abstract class Power
{
    private string name;
    public string Name { get => name; set => name = value; }
    private Element element;
    public Element Element { get => element; set => element = value; }
    private float baseDamage;
    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
    private IDamageType damageType;
    public IDamageType DamageType { get => damageType; set => damageType = value; }
    private float hitChance;
    public float HitChance { get => hitChance; set => hitChance = value; }
    private float maxCharges;
    public float MaxCharges { get => maxCharges; set => maxCharges = value; }
    private float currentCharges;
    public float CurrentCharges { get => currentCharges; set => currentCharges = value; }

    public void DisplayInfo()
    {
        Debug.Log($@"Power Name: {Name},
        Element: {Element},
        Max Charges: {MaxCharges},
        Current Charges: {CurrentCharges}");
    }

    public abstract BattleResult UsePower(Pikomon user, Pikomon target);

    public float CalculateDamage(Pikomon user, Pikomon target)
    {
        float BaseDamage = this.BaseDamage + (user.Element == this.Element ? 1.25f : 1);
        float Damage = DamageType == IDamageType.Physical ? user.Attack - target.Defense : user.SpiritualAttack - target.SpiritualDefense;
        float weaknessMultiplier = target.Element.CheckWeaknessAgainst(this.Element) ? 2 : target.Element.CheckStrengthAgainst(this.Element) ? 0.5f : 1;
        float TotalDamage = (BaseDamage + Damage) * weaknessMultiplier;
        if (TotalDamage < 0) TotalDamage = 0;   
        return TotalDamage;
    }
    public void AddCharge()
    {
        if (CurrentCharges < MaxCharges)
        {
            CurrentCharges++;
        }
    }
    public bool Hit()
    {
        if (Random.value > HitChance)
        {
            Debug.Log($"{Name} missed!");
            return false;
        }
        return true;
    }
}
