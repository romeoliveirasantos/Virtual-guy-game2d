using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Attributes")]
    public float speed;
    public float jumpForce;
    public int lifePlayer;
    public int pineapple;

    [Header("Components")]
    public Rigidbody2D rig;
    public Animator anim;
    public SpriteRenderer sprite;

    [Header("UI")]
    public TextMeshProUGUI pineappleText;
    public TextMeshProUGUI lifeplayerText;
    public GameObject gameOver;
    public GameObject FinalGame;


    private Vector2 direction;
    private bool IsGrounded;
    private bool recovery;



    

    // Start is called before the first frame update
    void Start()
    {
        lifeplayerText.text = lifePlayer.ToString();
        Time.timeScale = 1;

        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Jump();
        PlayAnim();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    //andar
    void Movement()
    {
        rig.velocity = new Vector2 (direction.x * speed, rig.velocity.y);
    }

    //pular
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded == true)
        { 
         rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
         IsGrounded = false;
        }
    }

    //morrer
    void Death()
    {
        if (lifePlayer <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //animações
    void PlayAnim()
    {
        if(direction.x > 0)
        {
            if(IsGrounded == true)
            {
                anim.SetInteger("transition", 1);
            }
            
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(direction.x < 0)
        {
            if (IsGrounded == true)
            {
                anim.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(direction.x == 0)
        {
            anim.SetInteger("transition", 0);
        }
    }

    public void Hit()
    {
        
        if (recovery == false)
        {
            StartCoroutine(Flick());
        }

        
    }

    IEnumerator Flick()
    {
        recovery = true;
        lifePlayer -= 1;
        Death();
        lifeplayerText.text = lifePlayer.ToString();
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1, 1, 1, 1);
        recovery = false;
        

    }

    public void IncreaseScore()
    {
        pineapple++;
        pineappleText.text = pineapple.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void FinalSceneGame()
    {
        SceneManager.LoadScene(0);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            IsGrounded = true;
        }
    }
}
