using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image currentHealthBar;

    private void Awake()
    {
        currentHealthBar.fillAmount = playerHealth.CurrentHealth / 3f;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.CurrentHealth / 3f;
    }
}