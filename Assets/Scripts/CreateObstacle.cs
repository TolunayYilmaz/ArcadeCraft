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
        playerControllerScript = GetComponent<PlayerController>();//obje araramasý yapmýyoruz çünkü bu kod istediðimiz objenin üstündedir.
    }


    void Obstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, obstaclePosition, obstaclePrefab.transform.rotation);
        }
    

    }
}

