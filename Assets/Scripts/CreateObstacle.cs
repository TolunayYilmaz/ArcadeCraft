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
        playerControllerScript = GetComponent<PlayerController>();//obje araramasý yapmýyoruz çünkü bu kod istediðimiz objenin üstündedir.
    }


    void Obstacle()
    {
        float x = Random.Range(3, 5);//üretimi random yapmak için sabit çalýþtýrýðýmýz metodun içne yeni bir metod ýnvokelayarak random çalýþmasýný saðladýk

        Invoke("RandomObsctacle", x);//ýnvokeseption


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

