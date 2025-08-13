
using UnityEngine;

public class PikoController : MonoBehaviour
{
    [Header("Pikomon References")]
    [Tooltip("Assign any type of Pikomon (Himon, Aquamon, etc.) from your ScriptableObject assets")]
    [SerializeField]
    private Pikomon pikomon;
    [Header("Runtime Creation")]
    [Tooltip("Enter a custom name for the Pikomon to be created at runtime")]
    [SerializeField] private string customName = "Pikomon";
    public string CustomName 
    { 
        get => customName; 
        set => customName = value; 
    }

    [Header("Runtime Info")]
    [SerializeField]
    private string pikomonName;

    [SerializeField]
    private int uniqueInstanceId;
    public int UniqueId => uniqueInstanceId;

    private void Awake()
    {
        uniqueInstanceId = System.Guid.NewGuid().GetHashCode();
        if (uniqueInstanceId < 0) uniqueInstanceId = -uniqueInstanceId;
    }

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
    public void SetPikomon(Pikomon newPikomon)
    {
        pikomon = newPikomon;
        pikomonName = newPikomon?.Name;

        if (ValidatePikomon(pikomon))
        {
            pikomon.DisplayInfo();
        }
    }

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