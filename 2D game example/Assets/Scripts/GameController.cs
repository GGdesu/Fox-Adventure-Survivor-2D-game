using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOver;

    public static GameController instance;
    
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvl_name){
        SceneManager.LoadScene(lvl_name);
    }
}
