using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {
    private Button button;
    private GameManager gameManager;

    [SerializeField]
    private int difficulty = 1;

    private void Start() {
        button = GetComponent<Button>();
        gameManager = FindObjectOfType<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty() {
        gameManager.StartGame(difficulty);
    }
}
