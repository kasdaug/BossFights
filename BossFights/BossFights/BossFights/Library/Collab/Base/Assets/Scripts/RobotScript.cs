using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{

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
    public bool robotOnTheRightBox = false;
    public GameObject p1box;


    private bool dead = false;

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

        if (groundChecking.position.y >= 1f)
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
            if (Input.GetButtonUp("P1Run"))
            {
                roboAnimator.SetBool("Run", false);
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
        /*if (col.gameObject.GetComponent<Renderer>().material.Equals(p1box.GetComponent<Renderer>().material))
        {
            robotOnTheRightBox = true;
        }*/
        if (col.gameObject.name == "Grey Stone")
        {
            robotOnTheRightBox = true;
        }
    }

    /* void OnCollisionEnter2D(Collision2D col)
     {
         if (GameObject.Find("p1Stand").GetComponent<Renderer>().material.Equals("Grey Stones"))
         {
             if (col.gameObject.name == "Grey Stone")
             {
                 robotOnTheRightBox = true;
             }
             else
             {
                 robotOnTheRightBox = false;
             }
         }
         else if (GameObject.Find("p1Stand").GetComponent<Renderer>().material.Equals("Sandy Orange"))
         {
             if (col.gameObject.name == "Sand")
             {
                 robotOnTheRightBox = true;
             }
             else
             {
                 robotOnTheRightBox = false;
             }
         }
         else if (GameObject.Find("p1Stand").GetComponent<Renderer>().material.Equals("Brown Stony"))
         {
             if (col.gameObject.name == "DarkBrown Stone")
             {
                 robotOnTheRightBox = true;
             }
             else
             {
                 robotOnTheRightBox = false;
             }
         }
         else if (GameObject.Find("p1Stand").GetComponent<Renderer>().material.Equals("Grass"))
         {
             if (col.gameObject.name == "Grass")
             {
                 robotOnTheRightBox = true;
             }
             else
             {
                 robotOnTheRightBox = false;
             }
         }
         else if (GameObject.Find("p1Stand").GetComponent<Renderer>().material.Equals("Brown Stony Light"))
         {
             if (col.gameObject.name == "Brown Stone")
             {
                 robotOnTheRightBox = true;
             }
             else
             {
                 robotOnTheRightBox = false;
             }
         }
         else if (GameObject.Find("p1Stand").GetComponent<Renderer>().material.Equals("Water Light Blue"))
         {
             if (col.gameObject.name == "Water")
             {
                 robotOnTheRightBox = true;
             }
             else
             {
                 robotOnTheRightBox = false;
             }
         }*/
}
}
