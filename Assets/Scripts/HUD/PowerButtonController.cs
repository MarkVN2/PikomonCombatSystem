using UnityEngine;
using TMPro;
public class PowerButtonController : MonoBehaviour
{
    [SerializeField] private GameObject symbolSpawn;
    [SerializeField] private TextMeshProUGUI charges;
    [SerializeField] private TextMeshProUGUI abilityName;

    public void SetCharges(string charges)
    {
        this.charges.text = charges;
    }
    public void SetAbilityName(string abilityName)
    {
        this.abilityName.text = abilityName;   
    }

}
