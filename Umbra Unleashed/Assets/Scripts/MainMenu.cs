using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;

    public int sceneIndex;

    private void Start() {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ShowMain() {
        mainMenu.SetActive(true);
    }

    public void StartGame() {
        SceneManager.LoadScene(sceneIndex);
    }

    public void HideMain() {
        mainMenu.SetActive(false);
    }

    public void ShowCredits() {
        creditsMenu.SetActive(true);
    }

    public void HideCredits() {
        creditsMenu.SetActive(false);
    }

   public void QuitGame()
    {
        Debug.Log("quitting application");
        Application.Quit();
    }
}
