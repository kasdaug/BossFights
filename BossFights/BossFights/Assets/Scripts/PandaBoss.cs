using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PandaBoss : MonoBehaviour
{

    private Animator pandaBossAnimator;
    public Rigidbody2D pandaRB { get; set; }
    float JumpForce = 1000f;
    public int startingHealth = 100;
    public Slider HPbar;
    private bool startbool;
    public Transform pandaChecks;


    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true; //Remove the possibility of character tilt
        pandaRB = GetComponent<Rigidbody2D>();
        pandaBossAnimator = GetComponentInChildren<Animator>();
        pandaBossAnimator.SetBool(("BossStart"), true);
  
    }

    // Update is called once per frame
    void Update()
    {



    }

    void FixedUpdate()
    {
        if (pandaBossAnimator.GetBool("BossStart") == true)
        {
            //transform.Translate(new Vector2(-2, 0));
            pandaBossAnimator.SetBool(("WalkLeft"), true);
            pandaBossAnimator.SetBool(("BossStart"), false);
        }

        if (pandaBossAnimator.GetBool("WalkLeft") == true)
        {
            pandaRB.velocity = new Vector2(-50, pandaRB.velocity.y);
            if (pandaChecks.position.x <= -20)
            {
                pandaBossAnimator.SetBool(("FightLeft"), true);
                pandaBossAnimator.SetBool(("WalkLeft"), false);
            }

        }

        if (pandaBossAnimator.GetBool("FightLeft") == true)
        {
            int i = 0;
            while (i < 0)
            {

            }
            pandaBossAnimator.SetBool(("WalkRight"), true);
            pandaBossAnimator.SetBool(("FightLeft"), false);
        }

        if (pandaBossAnimator.GetBool("WalkRight") == true)
        {

            pandaRB.velocity = new Vector2(50, pandaRB.velocity.y);
            if (pandaChecks.position.x >= 34)
            {
                //panda walks right
                //Idle for some time
                pandaBossAnimator.SetBool(("WalkRight"), false);
                pandaBossAnimator.SetBool(("LeftJump"), true);
            }
        }
            if (pandaBossAnimator.GetBool("LeftJump") == true)

            {
                pandaRB.velocity = new Vector2(-20, 5);
               // pandaRB.velocity = new Vector2(-20, 5);
               // pandaRB.velocity = new Vector2(-20, 5);

            if (pandaChecks.position.x <= -20)
                {
                    pandaBossAnimator.SetBool(("LeftJump"), false);
                    pandaBossAnimator.SetBool(("RightJump"), true);
                }

            }

            if (pandaBossAnimator.GetBool("RightJump") == true)
            {
                pandaRB.velocity = new Vector2(20, 5);

                if (pandaChecks.position.x > 34)
                {
                    //panda walks right
                    //Idle for some time
                    pandaBossAnimator.SetBool(("RightJump"), false);
                    startbool = true;
                }

            }
        }
    }

