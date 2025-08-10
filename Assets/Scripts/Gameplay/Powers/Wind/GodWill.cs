/// <para><strong>SPECIAL POWER</strong> </para>

public class GodWill : Power
{
    public GodWill()
    {
        Name = "God Will";
        Element = new Earth();
        HitChance = 0.90f;
        MaxCharges = 1;
        CurrentCharges = 1;
    }

    public override void UsePower(Pikomon user, Pikomon target)
    {
        throw new System.NotImplementedException();
    }
}