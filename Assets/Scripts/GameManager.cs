using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public GameObject MenuPanel;
 //   private PlayerController Game;
    public GameObject ScorePanel;

    public enum GameState
    {
        none,
        gameOver,

    }
    private GameState myState = GameState.none;  // %35_State_Loading_%35
    public GameState changeState
    {
        get { return myState; }
        set {
            myState = value;
          
            switch (myState)
            {
                case GameState.gameOver:
                    GameOver();
                    break;
                default:
                    break;
            }
        }

    }
    void Start()
    {
       // Game = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        MenuPanel.SetActive(false);
        ScorePanel.SetActive(true);
    }

    private void GameOver()
    {
        ScorePanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
       
    }
    public void Exit()
    {
       Application.Quit();

    }
}
