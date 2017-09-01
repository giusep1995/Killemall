using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManagement : MonoBehaviour {

	public void newGame() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void exitGame() {
        Application.Quit();
    }
}
