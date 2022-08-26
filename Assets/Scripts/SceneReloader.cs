using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    [SerializeField] private Button newGameButton;

    private void Awake()
    {
        newGameButton.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}