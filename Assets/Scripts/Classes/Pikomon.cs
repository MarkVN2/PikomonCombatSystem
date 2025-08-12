using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "New Pikomon", menuName = "Pikomon/Base Pikomon")]
public abstract class Pikomon : ScriptableObject
{
    protected abstract void InitializeDefaults();
    private void Reset()
    {
        InitializeDefaults();
    }

    private void OnEnable()
    {
        if (id == 0)
        {
            id = UnityEngine.Random.Range(1, 10000);
        }

        if (string.IsNullOrEmpty(Species) || Health <= 0)
        {
            InitializeDefaults();
        }
    }

    [ContextMenu("Reinitialize Pikomon")]
    public void ReinitializePikomon()
    {
        InitializeDefaults();
    }

    /// <summary>
    /// Creates a runtime instance of any Pikomon type with a custom name
    /// </summary>
    public static T CreateRuntimePikomon<T>(string customName) where T : Pikomon
    {
        var pikomon = CreateInstance<T>();
        pikomon.Name = customName;
        return pikomon;
    }
    [SerializeField]
    private string species;
    public string Species
    {
        get { return species; }
        set { species = value; }
    }

    [SerializeField]
    private string pikomonName;
    public string Name
    {
        get { return pikomonName; }
        set { pikomonName = value; }
    }
    [SerializeField]
    private int id;
    public int Id
    {
        get {
            if (id == 0)
            {
                id = UnityEngine.Random.Range(1, 10000);
            }
            return id;
        }
        set { id = value; }
    }
    [SerializeField]
    private IGender gender;
    public IGender Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    [SerializeField]
    private float height;
    public float Height
    {
        get { return height; }
        set { height = value; }
    }
    [SerializeField]
    private float weight;
    public float Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    [SerializeField]
    private Sprite frontSprite;
    public Sprite FrontSprite
    {
        get { return frontSprite; }
        set { frontSprite = value; }
    }

    [SerializeField]
    private Sprite backSprite;
    public Sprite BackSprite
    {
        get { return backSprite; }
        set { backSprite = value; }
    }
    [SerializeField]
    private float health;
    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField]
    private float maxHealth;
    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    private float attack;
    public float Attack
    {
        get { return attack; }
        set { attack = value; }
    }
    private float defense;
    public float Defense
    {
        get { return defense; }
        set { defense = value; }
    }
    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    private float spiritualAttack;
    public float SpiritualAttack
    {
        get { return spiritualAttack; }
        set { spiritualAttack = value; }
    }
    private float spiritualDefense;
    public float SpiritualDefense
    {
        get { return spiritualDefense; }
        set { spiritualDefense = value; }
    }
    [SerializeField]
    private List<Power> powers;
    public List<Power> Powers
    {
        get { return powers; }
        set { powers = value; }
    }
    public Element Element { get; set; }

[SerializeField]
private List<Effect> activeEffects = new List<Effect>();
public List<Effect> ActiveEffects { get => activeEffects; set => activeEffects = value; }

    public void DisplayInfo()
    {
        Debug.Log($@"Pikomon Name: {Name},
        Species: {Species},
        Id: {Id},
        Gender: {Gender},
        FrontSprite: {FrontSprite},
        BackSprite: {BackSprite},
        Health: {Health},
        Attack: {Attack},
        Defense: {Defense},
        Speed: {Speed},
        Spiritual Attack: {SpiritualAttack},
        Spiritual Defense: {SpiritualDefense},
        Powers: {string.Join(", ", Powers?.Select(p => p.Name) ?? new string[0])},
        Active Effects: {string.Join(", ", ActiveEffects?.Select(e => e.Name + " (Dur: " + e.Duration + ")") ?? new string[0])},
        Element: {Element}");
    }
    public void AddEffect(Effect effect)
    {
        activeEffects.Add(effect);
        effect.ApplyEffect();
    }

    public void ProcessEffects()
    {
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            Effect effect = activeEffects[i];
            effect.ProcessEffect();
        }
    }
    public void ActivateEffect(Effect effect)
    {
        effect.ApplyEffect();
    }
    public void AddPower(Power power)
    {
        if (Powers == null)
        {
            Powers = new List<Power>();
        }
        Powers.Add(power);
    }
    public void RemovePower(Power power)
    {
        if (Powers != null && Powers.Contains(power))
        {
            Powers.Remove(power);
        }
    }
    public bool HasPower<T>() where T : Power
    {
        return Powers.Any(p => p is T);
    }
    public void UsePower<T>(Pikomon target) where T : Power, new()
    {
        if (HasPower<T>())
        {
            Powers.OfType<T>().First().UsePower(this, target);
        }
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
        Debug.Log($"{Name} took {damage} damage. Remaining health: {Health}");
    }
    public void Heal(float amount)
    {
        Health += amount;
        if (Health > maxHealth) Health = maxHealth;
    }
}
