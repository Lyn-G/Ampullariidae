using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    // public GameObject mainMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPause) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause () {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    // public void LoadMainMenu() {
    //     Debug.Log("loading menu");
    //     pauseMenuUI.SetActive(false);
    //     mainMenuUI.SetActive(true);
    //     Time.timeScale = 0f;
    // }

    // public void QuitMenu() {
    //     pauseMenuUI.SetActive(false);
    //     Debug.Log("quitting game");
    //     Application.Quit();
    // }
}
