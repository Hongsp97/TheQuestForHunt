using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Invector.vCharacterController;
using Invector.Utils;
public class GameOverWindow : MonoBehaviour
{
    [Tooltip("Write the name of the level you want to load")]
    public string levelToLoad;
    [Tooltip("Assign here the spawnPoint name of the scene that you will load")]
    public string spawnPointName;


    public vThirdPersonInput playerCharacter;
    public vThirdPersonController playerStat;
    public GameObject[] gameoverWindow;
    void Start()
    {
        playerCharacter = GetComponentInParent<vThirdPersonInput>();
        playerStat = GetComponentInParent<vThirdPersonController>();
    }

    public void SetGameoverWindow()
    {   
        if (SceneManager.GetActiveScene().name == "Village")
        {
            gameoverWindow[0].SetActive(true);
            gameoverWindow[1].SetActive(false);
        }
        else
        {
            gameoverWindow[0].SetActive(false);
            gameoverWindow[1].SetActive(true);
        }
    }

    public void fullhealth()
    {

        playerStat._currentHealth = playerStat.maxHealth;
    }
}
