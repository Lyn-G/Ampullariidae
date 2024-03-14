using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("quitting application");
        Application.Quit();
    }
    

    public void PlayGame() {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the index of the next scene
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        // Load the next scene
        SceneManager.LoadScene(nextSceneIndex);
    }
}
