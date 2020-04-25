using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private List<GameObject> targets;
    [SerializeField]
    private float spawnRate = 1.0f;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int score;

    private void Start() {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    private void Update() {

    }

    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            UpdateScore(5);
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }
}
