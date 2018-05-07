using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //need this for the slider

public class SharkBossScript : MonoBehaviour {

    private float HP = 100;
    public float currentHP = 0;
    private Animator sharkBossAnimator;
    public Rigidbody2D sharkRB { get; set; }
    public float WalkSpeed = 20f;
    public Transform[] spots;
    public Transform[] jumpSpots;
    public Transform rangedFire;
    public GameObject projectiles;
    public Slider HPbar;
    private bool waitedOneSec = true;

	// Use this for initialization
	void Start () {

        currentHP = HP;
        //InvokeRepeating("DecreaseHealth",1f,1f);
        GetComponent<Rigidbody2D>().freezeRotation = true; //Remove the possibility of character tilt
        sharkRB = GetComponent<Rigidbody2D>();
        sharkBossAnimator = GetComponentInChildren<Animator>();
        sharkBossAnimator.SetBool("Idle", true);
        sharkBossAnimator.SetBool("Ground", true);
        StartCoroutine("SharkBoss");
        HPbar.value = HP;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Robot").GetComponent<RobotScript03>().robotOnTheShark &&
            GameObject.Find("Pumpkin").GetComponent<PumpkinScript03>().pumpkinOnTheShark)
        {
            if (waitedOneSec)
            {
                StartCoroutine("KillTheShark");
                DecreaseHealth();
            }
        }
    }

    IEnumerator KillTheShark()
    {
        waitedOneSec = false;
        yield return new WaitForSeconds(1);
        waitedOneSec = true;
    }

    IEnumerator SharkBoss()
    {
        if (HP >= 0)
        {
            int i = Random.Range(1, 3);

            switch (i)
            {
                case 1:
                    yield return new WaitForSeconds(2f);
                    StartCoroutine("diveAttack");
                    break;
                case 2:
                    yield return new WaitForSeconds(2f);
                    StartCoroutine("rangedAttack");
                    break;
                case 3:
                    yield return new WaitForSeconds(2f);
                    StartCoroutine("jumpAttack");
                    break;
                default:
                    yield return new WaitForSeconds(2f);
                    break;
            }
        
        }
    }

    IEnumerator diveAttack()
    {
        int i = Random.Range(1, 4);
        sharkBossAnimator.SetBool("LeftWalk", true);
        switch (i) //dive attacks
        { 

        case 1: //upperleft

        yield return new WaitForSeconds(2f);
       
        while (transform.position != spots[3].position) { 

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[3].position.x, spots[3].position.y), 2);

            yield return null;
        }

        while(transform.position != spots[1].position)
        {
                    sharkBossAnimator.SetBool("LeftWalk", false);
                    sharkBossAnimator.SetBool("RightWalk", true);
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[1].position.x, spots[1].position.y), 2);
            
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        while (transform.position != spots[0].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, spots[0].position.y), 2);
            
            yield return null;
        }
        yield return new WaitForSeconds(2f);

        while (transform.position != spots[2].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[2].position.x, spots[2].position.y), 2);
            
            yield return null;
        }
                sharkBossAnimator.SetBool("RightWalk", false);
                yield return new WaitForSeconds(1f);
                StartCoroutine("SharkBoss");
                break;

        case 2: //uppermiddleleft

                yield return new WaitForSeconds(2f);

                while (transform.position != spots[3].position)
                {

                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[3].position.x, spots[3].position.y), 2);

                    yield return null;
                }

                while (transform.position != spots[5].position)
                {
                    sharkBossAnimator.SetBool("LeftWalk", false);
                    sharkBossAnimator.SetBool("RightWalk", true);
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[5].position.x, spots[5].position.y), 2);

                    yield return null;
                }
                yield return new WaitForSeconds(1f);

                while (transform.position != spots[4].position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[4].position.x, spots[4].position.y), 2);

                    yield return null;
                }
                yield return new WaitForSeconds(2f);

                while (transform.position != spots[2].position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[2].position.x, spots[2].position.y), 2);

                    yield return null;
                }
                sharkBossAnimator.SetBool("RightWalk", false);
                yield return new WaitForSeconds(1f);
                StartCoroutine("SharkBoss");
                break;

        case 3: //uppermiddle

                yield return new WaitForSeconds(2f);

                while (transform.position != spots[3].position)
                {

                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[3].position.x, spots[3].position.y), 2);

                    yield return null;
                }

                while (transform.position != spots[9].position)
                {
                    sharkBossAnimator.SetBool("LeftWalk", false);
                    sharkBossAnimator.SetBool("RightWalk", true);
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[9].position.x, spots[9].position.y), 2);

                    yield return null;
                }
                yield return new WaitForSeconds(1f);

                while (transform.position != spots[8].position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[8].position.x, spots[8].position.y), 2);

                    yield return null;
                }
                yield return new WaitForSeconds(2f);

                while (transform.position != spots[2].position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[2].position.x, spots[2].position.y), 2);

                    yield return null;
                }
                sharkBossAnimator.SetBool("RightWalk", false);
                yield return new WaitForSeconds(1f);
                StartCoroutine("SharkBoss");
                break;

        case 4: //uppermiddleright

                yield return new WaitForSeconds(2f);

                while (transform.position != spots[3].position)
                {

                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[3].position.x, spots[3].position.y), 2);

                    yield return null;
                }

                while (transform.position != spots[7].position)
                {
                    sharkBossAnimator.SetBool("LeftWalk", false);
                    sharkBossAnimator.SetBool("RightWalk", true);
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[7].position.x, spots[7].position.y), 2);

                    yield return null;
                }
                yield return new WaitForSeconds(1f);

                while (transform.position != spots[6].position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[6].position.x, spots[6].position.y), 2);

                    yield return null;
                }
                yield return new WaitForSeconds(2f);

                while (transform.position != spots[2].position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[2].position.x, spots[2].position.y), 2);

                    yield return null;
                }
                sharkBossAnimator.SetBool("RightWalk", false);
                yield return new WaitForSeconds(1f);
                StartCoroutine("SharkBoss");
                break;

            default:
                sharkBossAnimator.SetBool("RightWalk", false);
                yield return new WaitForSeconds(1f);
                StartCoroutine("SharkBoss");
                break;

        }
    }

    IEnumerator rangedAttack()
    {
        //ranged {

        int i = Random.Range(1, 3);
        int j = 0;

        while (j <= i)
        {
            sharkBossAnimator.SetBool(("LeftFight"), true);
            yield return new WaitForSeconds(1f);
            GameObject bullet = (GameObject)Instantiate(projectiles, rangedFire.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
            j++;

            if(bullet.transform.position.x <= -20) //check this
            {
                Destroy(bullet);
            }
            yield return new WaitForSeconds(2f);
            sharkBossAnimator.SetBool(("LeftFight"), false);
        }

        sharkBossAnimator.SetBool(("IdleBoss"), true);
        StartCoroutine("SharkBoss"); 
        yield return null;
    }

    IEnumerator jumpAttack()
    {


        yield return new WaitForSeconds(1f);

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, spots[0].position.y), .2f);

        yield return new WaitForSeconds(1f);

        Debug.Log("do you reach dis?");


            transform.position = Vector2.MoveTowards(transform.position, new Vector2(jumpSpots[1].position.x, jumpSpots[1].position.y), 2);

            yield return null;
        

        while (transform.position != spots[8].position) //UpperMiddle
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[8].position.x, spots[8].position.y), 2);

            yield return null;
        }
        
        while (transform.position != jumpSpots[2].position) //jumpLeftMiddle
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(jumpSpots[0].position.x, jumpSpots[0].position.y), .25f);

            yield return null;
        }
        
        while (transform.position != spots[4].position) //UpperLeftMiddle
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[4].position.x, spots[4].position.y), .3f);

            yield return null;
        }
        
        while (transform.position != jumpSpots[3].position) //jumpLeft
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(jumpSpots[1].position.x, jumpSpots[1].position.y), 2);

            yield return null;
        }

        while (transform.position != spots[0].position) //UpperMiddle
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, spots[0].position.y), 2);

            yield return null;
        }

        while (transform.position != jumpSpots[3].position) //jumpLeft
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(jumpSpots[1].position.x, jumpSpots[1].position.y), 2);

            yield return null;
        }

        while (transform.position != spots[4].position) //UpperLeftMiddle
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[4].position.x, spots[4].position.y), 2);

            yield return null;
        }

        while (transform.position != jumpSpots[2].position) //jumpLeftMiddle
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(jumpSpots[0].position.x, jumpSpots[0].position.y), 2);

            yield return null;
        }

        while (transform.position != spots[8].position) //UpperMiddle
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[8].position.x, spots[8].position.y), 2);

            yield return null;
        }

        while (transform.position != jumpSpots[1].position) //jumpRightMiddle
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(jumpSpots[1].position.x, jumpSpots[1].position.y), 2);

            yield return null;
        }
  
        while (transform.position != spots[6].position) //UpperRightMiddle
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[6].position.x, spots[6].position.y), .2f);

            yield return null;
        }

        while (transform.position != jumpSpots[0].position) //jumpRight
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(jumpSpots[0].position.x, jumpSpots[0].position.y), 2);

            yield return null;
        
        }
        
    }


    void FixedUpdate()
    {
        if(currentHP == 0f)
        {
            HPbar.gameObject.SetActive(false);
            StartCoroutine("Death");
            
        }

    }

    void DecreaseHealth()
    {
        if (currentHP != 0)
        {
            currentHP -= 20f;
        }
        
        float myHealth = currentHP / HP;
    
            HPbar.transform.localScale = new Vector3(myHealth * 0.05f, 0.05f, 0.05f);
    }

    IEnumerator Death()
    {
        sharkBossAnimator.SetBool("Death", true);
        sharkBossAnimator.SetBool("Walk", false);
        sharkBossAnimator.SetBool("Run", false);
        sharkBossAnimator.SetBool("Jump", false);
        sharkBossAnimator.SetBool("Idle", false);
        sharkBossAnimator.SetBool("Ground", false);
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        GameObject.Find("SharkBoss Fight").GetComponent<Fight>().sharkIsDead = true;
    }
}
