
using UnityEngine;

public class PikoController : MonoBehaviour
{
    [Header("Pikomon References")]
    [Tooltip("Assign any type of Pikomon (Himon, Aquamon, etc.) from your ScriptableObject assets")]
    [SerializeField]
    private Pikomon pikomon;
    [Header("Runtime Creation")]
    [Tooltip("Enter a custom name for the Pikomon to be created at runtime")]
    public string customName = "Pikomon";

    [Header("Runtime Info")]
    [SerializeField]
    private string pikomonName;

    private void Start()
    {
        if (pikomon != null)
        {
            if (ValidatePikomon(pikomon))
            {
                pikomon.DisplayInfo();
            }
            else
            {
                Debug.LogError("Pikomon validation failed - some properties are null");
            }
        }
        else
        {
            Debug.LogWarning("No Pikomon assigned to PikoController");
        }
    }
    public Pikomon GetPikomon()
    {
        return pikomon;
    }
    /// <summary>
    /// Creates a runtime copy of the Pikomon instead of modifying the original asset
    /// </summary>
    private Pikomon CreateRuntimeCopy(Pikomon original, string newName)
    {

        Pikomon copy;

        if (original is Himon)
        {
            copy = Himon.CreateRuntimeHimon(newName);
        }
        else if (original is Aquamon)
        {
            copy = Aquamon.CreateRuntimeAquamon(newName);
        }
        else
        {
            // Fallback for base Pikomon type
            copy = ScriptableObject.CreateInstance<Pikomon>();
            copy.Name = newName;
            copy.Species = original.Species;
            copy.Health = original.Health;
            copy.MaxHealth = original.MaxHealth;
            copy.Attack = original.Attack;
            copy.Defense = original.Defense;
            copy.Speed = original.Speed;
            copy.SpiritualAttack = original.SpiritualAttack;
            copy.SpiritualDefense = original.SpiritualDefense;
            copy.Element = original.Element;
            copy.Powers = new System.Collections.Generic.List<Power>(original.Powers);
        }

        return copy;
    }

    /// <summary>
    /// Validates that all required Pikomon properties are initialized
    /// </summary>
    private bool ValidatePikomon(Pikomon piko)
    {
        if (piko == null)
        {
            Debug.LogError("Pikomon is null");
            return false;
        }

        if (string.IsNullOrEmpty(piko.Species))
        {
            Debug.LogError("Pikomon Species is null or empty");
            return false;
        }

        if (string.IsNullOrEmpty(piko.Name))
        {
            Debug.LogError("Pikomon Name is null or empty");
            return false;
        }

        if (piko.Element == null)
        {
            Debug.LogError("Pikomon Element is null");
            return false;
        }

        if (piko.Powers == null)
        {
            Debug.LogError("Pikomon Powers list is null");
            return false;
        }

        return true;
    }
}