using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_ : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
  
    public void ExitGame()
    {
        Application.Quit();
    }
}
