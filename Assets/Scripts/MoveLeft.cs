using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10;

    private PlayerController controller;
    [SerializeField]
    private float border = -10;
    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {

        if (controller.gameOver == false)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        
        if (transform.position.x < border && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (transform.position.x < border && gameObject.CompareTag("Coin"))// coin alýnamadýðý zaman mapin disinda yok edilir.
        {
            Destroy(gameObject);
        }
    }
}

