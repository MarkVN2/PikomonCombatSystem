using UnityEngine;
using System.Collections;
public class LifeLevel : MonoBehaviour
{

    [SerializeField] private GameObject healthBar;
    [SerializeField] private float animationSpeed = 1f;

    private float currentHealthPercentage = 1f;
    private float targetHealthPercentage = 1f;
    private Coroutine healthAnimationCoroutine;

    public void SetHealthPercentage(float percentage)
    {
        targetHealthPercentage = Mathf.Clamp01(percentage);
        if (healthAnimationCoroutine != null)
        {
            StopCoroutine(healthAnimationCoroutine);
        }
        healthAnimationCoroutine = StartCoroutine(AnimateHealthBar());
    }
    private IEnumerator AnimateHealthBar()
    {
        while (Mathf.Abs(currentHealthPercentage - targetHealthPercentage) > 0.01f)
        {
            currentHealthPercentage = Mathf.MoveTowards(currentHealthPercentage, targetHealthPercentage, animationSpeed * Time.deltaTime);
            if (healthBar != null)
            {
                healthBar.transform.localScale = new Vector3(7.7f * currentHealthPercentage, 1f, 1f);
            }
            yield return null;
        }

        currentHealthPercentage = targetHealthPercentage;
        if (healthBar != null)
        {
            healthBar.transform.localScale = new Vector3(7.7f * currentHealthPercentage, 1f, 1f);
        }
    }
}
