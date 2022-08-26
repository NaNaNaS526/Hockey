using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private AudioSource audioSource;
    private const int StartingHealth = 3;
    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = StartingHealth;
    }

    public void TakeDamage()
    {
        CurrentHealth -= 1;
        audioSource.Play();
        if (CurrentHealth <= 0)
        {
            defeatPanel.SetActive(true);
        }
    }
}