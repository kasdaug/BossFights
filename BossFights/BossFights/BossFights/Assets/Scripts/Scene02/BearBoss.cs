using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearBoss : MonoBehaviour {

    public GameObject player1Box;
    public GameObject player2Box;
    private float HP = 100;
    public float currentHP = 0;
    public Slider HPbar;
    private Animator bearAnimator;
    public int materialNr1;
    public int materialNr2;


    public Text counterText;

    public Material[] materials;
    public GameObject[] rocks;
    private int nrRockR = 1;
    private int nrRockP = 1;
    private bool bossDead = false;
    public GameObject bear;
    public GameObject[] yes;
    public GameObject robot;
    public GameObject pumpkin;
    private Vector3 vector = new Vector3(0, 15, 0);
    public GameObject winPanel;

    // Use this for initialization
    void Start () {
        FindObjectOfType<AudioManager>().Play("levelMusic");
        currentHP = HP;
        bearAnimator = GetComponentInChildren<Animator>();
        StartCoroutine("countDown");
        Invoke("Roll", 3.0f);
    }


	
	// Update is called once per frame
	void Update () {
        if (currentHP == 0f)
        {
            HPbar.gameObject.SetActive(false);
            StartCoroutine("Death");
            
        }
        if (GameObject.Find("Robot").GetComponent<RobotScript2>().robotOnTheRightBox)
        {
            yes[0].SetActive(true);
        }
        else { yes[0].SetActive(false); };
        if (GameObject.Find("Pumpkin").GetComponent<PumpkinScript2>().pumpkinOnTheRightBox)
        {
            yes[1].SetActive(true);
        }
        else { yes[1].SetActive(false); };
    }

    void FixedUpdate()
    {
        if(currentHP <= 75)
        {
            StartCoroutine("seventyfive");
        }
        if(currentHP <= 50)
        {
            StartCoroutine("fifty");
        }
        if(currentHP <= 25) {
            StartCoroutine("twentyfive");
        }
        if(currentHP <= 0)
        {
            bearAnimator.SetBool(("Idle"), true);
            HPbar.gameObject.SetActive(false);
            StartCoroutine("Death");
        }
    }

    void Roll() //Method for rolling random material to playerboxes
    {
        //how to copy material and save it to a gameobject.
        //meshrenderer
        robot.GetComponent<Transform>().Translate(Time.deltaTime * vector * 1);
        pumpkin.GetComponent<Transform>().Translate(Time.deltaTime * vector * 1);
        materialNr1 = Array.IndexOf(materials, materials.RandomItem());
        var box1color = materials[materialNr1];
        materialNr2 = Array.IndexOf(materials, materials.RandomItem());
        var box2color = materials[materialNr2];
        while (box1color.Equals(box2color))
        {
            materialNr2 = Array.IndexOf(materials, materials.RandomItem());
            box2color = materials[materialNr2];
        }
        player1Box.GetComponent<Renderer>().material = box1color;
        player2Box.GetComponent<Renderer>().material = box2color;
        Invoke("CheckPlayerBoxes",10.0f);
    }

    IEnumerator countDown()
    {
        FindObjectOfType<AudioManager>().Play("321go");
        string[] counter = { "3", "2", "1", "go" };
        for (int i = 0; i < counter.Length; i++)
        {
            counterText.text = counter[i];
            yield return new WaitForSeconds(1);
        }
    }

    void CheckPlayerBoxes() //method to check if players are in the correct boxes
    {
        if (GameObject.Find("Robot").GetComponent<RobotScript2>().robotOnTheRightBox &&
            GameObject.Find("Pumpkin").GetComponent<PumpkinScript2>().pumpkinOnTheRightBox)
        {
            Debug.Log("Success");
            Invoke("DecreaseHealth",0f); //to show health go down
        }
        else
        {
            Debug.Log("Fail");
            //falling rock on Robot
            if (GameObject.Find("Robot").GetComponent<RobotScript2>().robotOnTheRightBox==false && nrRockR == 1)
            {
                rocks[0].SetActive(true);
                nrRockR = 2;
            }
            else if(GameObject.Find("Robot").GetComponent<RobotScript2>().robotOnTheRightBox == false && nrRockR == 2)
            {
                rocks[1].SetActive(true);
                nrRockR = 3;
            }
            else if(GameObject.Find("Robot").GetComponent<RobotScript2>().robotOnTheRightBox == false && nrRockR == 3)
            {
                rocks[2].SetActive(true);
                Debug.Log("Game over");
            }
            //falling rock on Pumpkin
            if (GameObject.Find("Pumpkin").GetComponent<PumpkinScript2>().pumpkinOnTheRightBox == false && nrRockP == 1)
            {
                rocks[3].SetActive(true);
                nrRockP = 2;
            }
            else if (GameObject.Find("Pumpkin").GetComponent<PumpkinScript2>().pumpkinOnTheRightBox == false && nrRockP == 2)
            {
                rocks[4].SetActive(true);
                nrRockP = 3;
            }
            else if (GameObject.Find("Pumpkin").GetComponent<PumpkinScript2>().pumpkinOnTheRightBox == false && nrRockP == 3)
            {
                rocks[5].SetActive(true);
                Debug.Log("Game over");
            }
        }
        if(bossDead)
        {
            Destroy(bear);
            Debug.Log("YOU WIN!");
            winPanel.SetActive(true);
        }
        else
        {
            StartCoroutine("countDown");
            Invoke("Roll", 3.0f);
        }
        
    }

    void DecreaseHealth()
    {
        FindObjectOfType<AudioManager>().Play("bearRoar");
        currentHP -= 19f;
        if (currentHP > 5)
        {
            //do nothing
        }
        else
        {
            bossDead = true;
        }

        float myHealth = currentHP / HP;

        HPbar.transform.localScale = new Vector3(myHealth * 0.02f, 0.05f, 0.05f);

    }

    IEnumerator Death()
    {
        /*bearAnimator.SetBool("dead", true);
        bearAnimator.SetBool("WalkLeft", false);
        bearAnimator.SetBool("WalkRight", false);
        bearAnimator.SetBool("Idle", false);
        bearAnimator.SetBool("FightLeft", false);
        bearAnimator.SetBool("LeftJump", false);
        bearAnimator.SetBool("RightJump", false);
        bearAnimator.SetBool("BossStart", false);*/

        yield return new WaitForSeconds(3);
        //Destroy(this.gameObject);

    }


    IEnumerator twentyfive()
    {

        //method for 25%
        yield return null;

    }

    IEnumerator fifty()
    {
        //method for 50%
        yield return null;
    }

    IEnumerator seventyfive()
    {
        //method for 75%
        yield return null;
    }

}


public static class ArrayExtension
{
    //This is an extension method. RandomItem() will exist on all arrays
    public static T RandomItem<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }
}
