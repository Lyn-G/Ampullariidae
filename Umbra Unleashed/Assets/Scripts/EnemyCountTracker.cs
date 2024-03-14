using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCountTracker : MonoBehaviour
{
    public string sceneName; // this is the name of the scene u want to go to!
    //public int sceneIndex;
    public int EnemyCount;

    public void decrement()
    {
        EnemyCount--;
        if (EnemyCount < 0)
        {
            // change it using scene name
            SceneManager.LoadScene(sceneName);

            // or modify to use scene index- uncomment this and change scene name to an
            /*public void LoadSceneByIndex(int sceneIndex)
            {
            SceneManager.LoadScene(sceneIndex);
            }*/

        }
    }
}
