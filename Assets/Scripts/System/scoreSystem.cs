using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreSystem : MonoBehaviour {

    public int time = 60;
    public int health = 100;

    public Image bgTime; 

    private int score = 0;
    private Text Time;
    private Text Score;
    private Text Health;

	void Start () {
        Score = this.GetComponent<Text>();
        Time = GameObject.FindGameObjectWithTag("time").GetComponent<Text>();
        Health = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        StartCoroutine(remainingTime());
	}
	
    public void addPoint(int points) {
        score += points;
        Score.text = "Score: " + score;
    }

    public void deleteHealth(int health) {
        this.health -= health;
        Health.text = "Health: " + this.health;
        if (this.health <= 0)
            endGame();
    }

    IEnumerator remainingTime() {
        for (int i = time; i >= 0; i--) {
            Time.text = "Time: " + i ;
            if (i <= 10)
                remainingTimeColor();
            yield return new WaitForSeconds(1);
        }
        endGame();
    }

    void endGame() {
        if (PlayerPrefs.GetInt("score") < score)
            PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene("Game_over", LoadSceneMode.Single);
    }

    void remainingTimeColor() {
        bgTime.color = Color.red;
    }
}
