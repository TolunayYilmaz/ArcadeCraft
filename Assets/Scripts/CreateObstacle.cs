using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;
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
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, obstaclePosition, obstaclePrefab.transform.rotation);
        }
    

    }
}

