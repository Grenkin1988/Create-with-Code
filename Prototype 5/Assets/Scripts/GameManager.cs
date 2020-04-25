using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private List<GameObject> targets;
    [SerializeField]
    private float spawnRate = 1.0f;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int score;

    [SerializeField]
    private GameObject titleScreen;

    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private Button restartButton;

    public bool IsGameActive { get; private set; }

    private void Start() {
    }

    public void StartGame(int difficulty) {
        IsGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.SetActive(false);
    }

    IEnumerator SpawnTarget() {
        while (IsGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = UnityEngine.Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            UpdateScore(5);
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver() {
        IsGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
