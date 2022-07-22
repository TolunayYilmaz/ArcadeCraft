using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody PlayerRb;
    public float jumpForce = 10;
    public float GravityModifiers = 1;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnim;
    public ParticleSystem deadefect;
    public ParticleSystem runEfect;
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifiers;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Jump();

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround&&!gameOver)

        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            runEfect.Stop();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            runEfect.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            deadefect.Play();
            runEfect.Stop();
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

        }
    }
}
