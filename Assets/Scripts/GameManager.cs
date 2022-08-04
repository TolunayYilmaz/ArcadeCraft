using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public GameObject MenuPanel;
    private PlayerController Game;
    public GameObject ScorePanel;

    void Start()
    {
        Game = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        MenuPanel.SetActive(false);
        ScorePanel.SetActive(true);
    }
    private void Update()
    {
        if (Game.gameOver == true)
        {
            ScorePanel.SetActive(false);
            MenuPanel.SetActive(true);

        }
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
