using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public static bool gameIsOver = false;
    public GameObject gameOverMenu;


    public void gameOverSet() {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsOver = true;
    }

    public void gameOverResume() {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsOver = false;
    }
}
