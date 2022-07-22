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
    public GameObject coin;
    void Start()
    {
        InvokeRepeating("Obstacle", startDelay, repeatRate);
        InvokeRepeating("CreateCoin", startDelay, repeatRate);
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
    void CreateCoin()//random sayida coin üretmesi için yazdim
    {
        if (playerControllerScript.gameOver==false)
        {
            for (int i = 0; i < Random.Range(0, 4); i++)
            {
                Instantiate(coin, new Vector3(coin.transform.position.x + i, coin.transform.position.y + 5, coin.transform.position.z), coin.transform.rotation);

            }

        }
   
    }
}

