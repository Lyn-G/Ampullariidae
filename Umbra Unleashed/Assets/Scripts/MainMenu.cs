using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;

    private void Start() {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ShowMain() {
        mainMenu.SetActive(true);
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
