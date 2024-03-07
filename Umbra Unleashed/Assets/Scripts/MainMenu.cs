using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // public GameObject mainMenu;

    // Start is called before the first frame update
//     void Start()
//     {
//         Time.timeScale = 0f;
//         mainMenu.SetActive(true);
//     }

//    public void StartGame() {
//         mainMenu.SetActive(false);
//         Time.timeScale = 1f;
//    }

   public void QuitGame()
    {
        Application.Quit();
    }
}
