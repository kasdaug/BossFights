using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScript03 : MonoBehaviour
{


    private Animator pumpkinAnimator;
    // int jumpHash = Animator.StringToHash("JumpAnimation");
    // int runStateHash = Animator.StringToHash("Base Layer.RunAnimation");
    public Rigidbody2D pumpkinRB { get; set; }
    float JumpForce = 300f;
    public float WalkSpeed;
    public bool facingRight = true;
    public Transform groundChecking; //Check that the user is on the ground, to avoid unlimited jumps
    //private float groundDistance = .2f;
    private bool ground;
    public AudioClip jumpSound;
    public AudioClip ShootSound;
    AudioSource p2Audio;
    //private bool dead = false;
    private int Health = 3;
    public GameObject[] hearts;
    public bool pumpkinOnTheShark=false;

    void Start()
    {

        GetComponent<Rigidbody2D>().freezeRotation = true; //Remove the possibility of character tilt
        pumpkinRB = GetComponent<Rigidbody2D>();
        pumpkinAnimator = GetComponentInChildren<Animator>();
        pumpkinAnimator.SetBool("Idle", true);
        pumpkinAnimator.SetBool("Ground", true);


    }

    void Update()
    {
        //float WalkAnimation = Input.GetAxis("Vertical");
        // roboAnimator.SetFloat("Speed", WalkAnimation);

        if (Input.GetButtonDown("P2Jump") && ground == true) //when pressed, play animation
        {
            pumpkinAnimator.SetBool("Jump", true);
            //roboAnimator.play("JumpAnimation");
            pumpkinRB.AddForce(new Vector2(0, JumpForce));
            FindObjectOfType<AudioManager>().Play("PlayerJump");
            // p2Audio.clip = jumpSound;
            // p2Audio.Play();
        }
        if (Input.GetButtonUp("P2Jump")) //when not pressed, set boolean to false
        {
            pumpkinAnimator.SetBool("Jump", false);
            //roboAnimator.play("JumpAnimation");
        }

        if (Health <= 0)
        {
            pumpkinAnimator.SetBool(("Death"), true);
            Death();
        }


    }

    /*void OnCollisionEnter2D(Collision2D boss)
    {
        if (boss.gameObject.CompareTag("Boss"))
        {
         
            PlayerDamage();
        }
    }*/


    void FixedUpdate() //used for walking/running
    {


        if (groundChecking.position.y >= 8f) //groundchecking to make sure that only one jump can be done
        {
            ground = false;
        }
        if (groundChecking.position.y < 8f) //reset ground to true below this value
        {
            ground = true;
        }

        float P2Horizontal = Input.GetAxis("P2Horizontal"); //Input axis from inputmanager
        Vector3 movement = new Vector3(P2Horizontal, 0, 0);
        if (P2Horizontal > 0)
        {
            //pumpkinRB.AddForce(movement * WalkSpeed, 0);
            pumpkinRB.velocity = new Vector2(P2Horizontal * WalkSpeed, 0);
            pumpkinAnimator.SetBool("Walk", true);
        }
        if (P2Horizontal < 0)
        {
            pumpkinRB.velocity = new Vector2(P2Horizontal * WalkSpeed, 0);
            Flip();
            pumpkinAnimator.SetBool("Walk", true);

        }

        /*
        if (Input.GetButtonDown("P1Horizontal"))
        {
            roboAnimator.SetBool("Walk", true);
            roboRB.AddForce(new Vector2(WalkSpeed,0));
            if (Input.GetButtonDown("P1Run"))
            {
                roboAnimator.SetBool("Walk", false);
                roboAnimator.SetBool("Run", true);
                roboRB.AddForce(new Vector2(RunSpeed, 0));
            }
            if (Input.GetButtonUp("P1Run"))
            {
                roboAnimator.SetBool("Walk", true);
                roboAnimator.SetBool("Run", false);
            }
        }
        if (Input.GetButtonUp("P1Horizontal"))
        {
            roboAnimator.SetBool("Walk", false);
        }
         
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("Ground", grounded);
        
        float P1horizontal = Input.GetAxis("P1Horizontal");
        if (!dead && !attack)
        {
            roboAnimator.SetFloat(WalkSpeed, roboRB.velocity.y);
            roboAnimator.SetFloat(RunSpeed, Mathf.Abs(P1horizontal));
            roboRB.velocity = new Vector2(P1horizontal * WalkSpeed, roboRB.velocity.y);
        }
        if (P1horizontal > 0 && !facingRight && !dead && !attack)
        {
            Flip(P1horizontal);
        }

        else if (P1horizontal < 0 && facingRight && !dead && !attack)
        {
            Flip(P1horizontal);
        }

        */
    }

    void Flip() //Script for flipping the direction of the player, depending on horizontal axis
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void PlayerDamage()
    {
        Health--;
        Debug.Log("Current Health: " + Health);
    }

    IEnumerator Death()
    {

        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (hearts[2].activeSelf)
            {
                hearts[2].SetActive(false);
                hearts[5].SetActive(true);
                Destroy(col.gameObject);
            }
            else if (hearts[2].activeSelf == false && hearts[1].activeSelf)
            {
                hearts[1].SetActive(false);
                hearts[4].SetActive(true);
                Destroy(col.gameObject);
            }
            else
            {
                hearts[0].SetActive(false);
                hearts[3].SetActive(true);
                Destroy(col.gameObject);
                Destroy(gameObject);
                GameObject.Find("SharkBoss Fight").GetComponent<Fight>().pumpkinIsDead = true;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name== "SharkBoss")
        {
            pumpkinOnTheShark = true;
        }
        else
        {
            pumpkinOnTheShark = false;
        }
    }


}

