using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverManagement : MonoBehaviour {

    public GameObject Score;

	void Start () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Score.GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("score");
	}

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
