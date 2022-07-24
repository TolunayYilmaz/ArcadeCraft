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
    void CreateCoin()//random sayida coin �retmesi i�in yazdim
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

