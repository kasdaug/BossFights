using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PandaBoss : MonoBehaviour
{
    private float HP = 100;
    public float currentHP = 0;
    private Animator pandaBossAnimator;
    public Rigidbody2D pandaRB { get; set; }
    float JumpForce = 1000f;
    public Slider HPbar;

    public Transform[] checks;
    ParticleSystem bossHit;
    CapsuleCollider bossCollider;
    private bool facingLeft = true;
    private bool healthBool;


    void Awake()
    {
        //bossCollider = GetComponent<Collider>();
        //bossBoxCollider = GetComponent();
    }

    // Use this for initialization
    void Start()
    {
        currentHP = HP;
        GetComponent<Rigidbody2D>().freezeRotation = true; //Remove the possibility of character tilt
        pandaRB = GetComponent<Rigidbody2D>();
        pandaBossAnimator = GetComponentInChildren<Animator>();
        pandaBossAnimator.SetBool(("BossStart"), true);
        //InvokeRepeating("DecreaseHealth", 1f, 1f); //to show health go down
        healthBool = true; //set boolean to true, so that the boss can take damage



    }

    void FixedUpdate()
    {


        if (currentHP <= 0)
        {
            pandaBossAnimator.SetBool(("Idle"), true);
            HPbar.gameObject.SetActive(false);
            pandaBossAnimator.SetBool("Dead", true);
            pandaBossAnimator.SetBool("RightJump", false);
            pandaBossAnimator.SetBool("LeftJump", false);
            pandaBossAnimator.SetBool("WalkRight", false);
            pandaBossAnimator.SetBool("WalkLeft", false);
            pandaBossAnimator.SetBool("FightLeft", false);
            pandaBossAnimator.SetBool("Idle", false);
            pandaBossAnimator.SetBool("BossStart", false);
            StartCoroutine("Death");
        }

        if (facingLeft == false)
        {
            //bossCollider.transform.Translate(Vector3.forward * 2);
        }


        if (pandaBossAnimator.GetBool("BossStart") == true)
        {
            //transform.Translate(new Vector2(-2, 0));
            pandaBossAnimator.SetBool(("WalkLeft"), true);
            pandaBossAnimator.SetBool(("BossStart"), false);
            facingLeft = true;
        }

        if (pandaBossAnimator.GetBool("WalkLeft") == true)
        {
            //StartCoroutine("moveBossForward");
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20, 4), 8 * Time.deltaTime);
            pandaBossAnimator.SetBool(("WalkRight"), true);
            if (transform.position.x <= -20)
            {
                pandaBossAnimator.SetBool(("WalkLeft"), false);
                facingLeft = true;


            }
        }

        if (pandaBossAnimator.GetBool("WalkRight") == true)
        {
            facingLeft = false;

            Debug.Log("Do you reach this?");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(20, 4), 8 * Time.deltaTime);


            if (transform.position.x >= -20.9)
            {

                //transform.position = Vector2.MoveTowards(transform.position, new Vector2(20, 4), 0.8f * Time.deltaTime);
                //panda walks right
                //Idle for some time
                pandaBossAnimator.SetBool(("WalkRight"), false);
                pandaBossAnimator.SetBool(("BossStart"), true);
                //pandaBossAnimator.SetBool(("LeftJump"), true);
            }
        }

        /*
        if (pandaBossAnimator.GetBool("LeftJump") == true)

        {
            pandaRB.AddForce(new Vector2(-18, 4));

            if (transform.position.x <= -20)
            {
                pandaBossAnimator.SetBool(("LeftJump"), false);
                pandaBossAnimator.SetBool(("RightJump"), true);
            }
        }

        if (pandaBossAnimator.GetBool("RightJump") == true)
        {

            //pandaRB.AddForce(new Vector2(20, 2));

            if (transform.position.x >= -4.9)
            {
                //panda walks right
                //Idle for some time
                pandaBossAnimator.SetBool(("RightJump"), false);
                pandaBossAnimator.SetBool(("BossStart"), true);


            }
        }*/
    }

    public void DecreaseHealth()
    {


        StartCoroutine("DecHealthNum");
        if (currentHP != 0 && healthBool == true)
        {
            currentHP = currentHP - 10;
            healthBool = false;
        }

        float myHealth = currentHP / HP;

        HPbar.transform.localScale = new Vector3(myHealth * 0.05f, 0.2f, 0.05f);

        //yield return new WaitForSeconds(2);

    }

    IEnumerator DecHealthNum()
    {
        yield return new WaitForSeconds(3); //call the CoRoutine to wait for 3 seconds and reset boolean;

        healthBool = true;

        yield return null;
    }


    IEnumerator Death()
    {

        pandaRB.isKinematic = true;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        GameObject.Find("PandaBossBattle").GetComponent<Battle>().pandaIsDead = true;
    }
    IEnumerator moveBossForward()
    {
        if (transform.position != checks[0].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(checks[0].position.x, checks[0].position.y), 0.2f);
        }
        yield return new WaitForSeconds(1);
    }

}

