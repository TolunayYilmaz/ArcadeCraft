using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float startDelay = 2f;
    private float repeatRate = 2f;
    public Vector3 obstaclePosition = new Vector3(25, 1, 0);
    private PlayerController playerControllerScript;
    void Start()
    {
        InvokeRepeating("Obstacle", startDelay, repeatRate);
        playerControllerScript = GetComponent<PlayerController>();//obje araramas� yapm�yoruz ��nk� bu kod istedi�imiz objenin �st�ndedir.
    }


    void Obstacle()
    {
        float x = Random.Range(3, 5);//�retimi random yapmak i�in sabit �al��t�r���m�z metodun i�ne yeni bir metod �nvokelayarak random �al��mas�n� sa�lad�k

        Invoke("RandomObsctacle", x);//�nvokeseption


    }
    void RandomObsctacle()
    {
        int y = Random.Range(0, 2);
        if (playerControllerScript.gameOver == false)

        {
            Instantiate(obstaclePrefabs[y], obstaclePosition, obstaclePrefabs[y].transform.rotation);
        }

    }
}

