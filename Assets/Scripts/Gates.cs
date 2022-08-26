using TMPro;
using UnityEngine;
public class Gates : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource audioSource;
    private int _score;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puck"))
        {
            _score += 50;
            scoreText.text = $"Score: {_score}";
            audioSource.Play();
        }
    }
}
