using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody PlayerRb;
    public float jumpForce = 9;
    public float GravityModifiers = 1.5f;
    public bool isOnGround =true;
    public int doubleJumpControl = 0;
    public bool gameOver;
    private Animator playerAnim;
    public ParticleSystem deadefect;
    public ParticleSystem runEfect;
    public AudioClip jumpSound;
    public AudioClip deadSound;
    private AudioSource playerAudio;
    public Text scoreUiText;
    private int score = 0;
    public Text highScore;
    private GameManager gameManager;
    


    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0,-GravityModifiers, 0);
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();//highsocru getirmektedir.


        gameManager =GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();//Game Manager tipindeki script çekildi
    }

    // Update is called once per frame
    void Update()
    {
        
        Jump();
        doubleJump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround &&!gameOver)

        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround =false;
            playerAnim.SetTrigger("Jump_trig");
            runEfect.Stop();
            playerAudio.PlayOneShot(jumpSound);
        }



    }
    private void doubleJump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !isOnGround && !gameOver)
        {
            doubleJumpControl += 1;//boolean deðer seçilmedi çünkü ikinci basýþta ayný hareketi sürekli tetiklediði için sonsuza kadar basma hakký tanýmaktadur.
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJumpControl == 1 && !isOnGround)

        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            playerAnim.SetTrigger("Jump_trig");
            runEfect.Stop();
            playerAudio.PlayOneShot(jumpSound);
            Debug.Log("Double");


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJumpControl = 0;
            runEfect.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            deadefect.Play();
            runEfect.Stop();
            Debug.Log("Game Over");
            gameOver = true;
            //Alt kodda game managerdaki state machine kullanbýlarak içindeki state deðiþtirildi.
            gameManager.changeState = GameManager.GameState.gameOver;//GameState sayesinde GameManager scripttindeki update komutu iptal edildi ve performans artýþý saðlandý
           
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(deadSound);

        }
 

    }
    private void OnTriggerEnter(Collider other)//coin toplarken coinlere çarpýþmamasý için trigger kullanýldý
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score += 10;
            scoreUiText.text = "Score: " + score.ToString();

            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore.text=score.ToString();
            }
        }
    }
}
