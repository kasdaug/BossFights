using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript01 : MonoBehaviour {
    private Animator roboAnimator;
    // int jumpHash = Animator.StringToHash("JumpAnimation");
    // int runStateHash = Animator.StringToHash("Base Layer.RunAnimation");
    public Rigidbody2D roboRB { get; set; }
    float JumpForce = 300f;
    public float WalkSpeed;
    float RunSpeed = 50f;
    public bool facingRight = true;
    public Transform groundChecking;
    private float groundDistance = .2f;
    private bool ground;
    private int HP = 3;
    //public Text hpText;
    public AudioClip JumpSound;
    public AudioClip ShootSound;
    public GameObject Rock;
    private bool dead = false;
    public Transform rockPlacement;
    public GameObject[] hearts;

    void Start()
    {

        GetComponent<Rigidbody2D>().freezeRotation = true; //Remove the possibility of character tilt
        roboRB = GetComponent<Rigidbody2D>();
        roboAnimator = GetComponentInChildren<Animator>();
        roboAnimator.SetBool("Idle", true);
        roboAnimator.SetBool("Ground", true);

    }

    void Update()
    {

        ground = roboAnimator.GetBool("Ground"); //get boolean each frame from the Animator

        //float WalkAnimation = Input.GetAxis("Vertical");
        // roboAnimator.SetFloat("Speed", WalkAnimation);

        if (Input.GetButtonDown("P1Jump") && ground == true) //when pressed, play animation
        {
            roboAnimator.SetBool("Jump", true);
            //roboAnimator.play("JumpAnimation");
            Debug.Log("Robo Jump");
            roboRB.AddForce(new Vector2(0, JumpForce));
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }
        if (Input.GetButtonUp("P1Jump")) //when not pressed, set boolean to false
        {
            roboAnimator.SetBool("Jump", false);
            //roboAnimator.play("JumpAnimation");
        }




    }

    void FixedUpdate() //used for walking/running
    {


        if (groundChecking.position.y >= 4f)
        {
            roboAnimator.SetBool("Ground", false);
        }
        if (groundChecking.position.y <= 0f)
        {
            roboAnimator.SetBool("Ground", true);
        }

        float P1Horizontal = Input.GetAxis("Horizontal");

        if (P1Horizontal > 0)
        {

            roboRB.velocity = new Vector2(P1Horizontal * WalkSpeed, roboRB.velocity.y);
            roboAnimator.SetBool("Walk", true);
            if (Input.GetButtonDown("P1Run"))
            {
                facingRight = true;
                roboAnimator.SetBool("Run", true);
                roboRB.velocity = new Vector2(P1Horizontal * RunSpeed, roboRB.velocity.y);
            }

  
        }
        if (P1Horizontal < 0)
        {
            roboRB.velocity = new Vector2(P1Horizontal * WalkSpeed, 0);
            facingRight = false;
            if (facingRight == false)
            {
                Flip();
            }

            roboAnimator.SetBool("Walk", true);

        }

    }

    void Flip() //Script for flipping the direction of the player, depending on horizontal axis
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Death()
    {
        roboAnimator.SetBool("Death", true);
        roboAnimator.SetBool("Walk", false);
        roboAnimator.SetBool("Run", false);
        roboAnimator.SetBool("Jump", false);
        roboAnimator.SetBool("Idle", false);
        roboAnimator.SetBool("Ground", false);

        HP--;
    }

    void OnCollisionEnter2D(Collision2D col)
    { 



    }
   
}
