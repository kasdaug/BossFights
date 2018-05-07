using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearBoss : MonoBehaviour {

    public GameObject player1Box;
    public GameObject player2Box;
    private int HP = 100;
    public Slider HPbar;
    private Animator bearAnimator;


    public Text counterText;

    public Material[] materials;

	// Use this for initialization
	void Start () {
        bearAnimator = GetComponentInChildren<Animator>();
        StartCoroutine("countDown");
        FindObjectOfType<AudioManager>().Play("321go");
        //Invoke("Roll", 3.0f);
        Roll();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    void FixedUpdate()
    {
        if(HP <= 75)
        {
            bearAnimator.SetBool(("bearWalk"), true);
        }
        if(HP <= 50)
        {
            bearAnimator.SetBool(("bearSmash"), true);
        }
        if(HP <= 25) {
            bearAnimator.SetBool(("bearKick"), true);
                }
        if(HP <= 0)
        {
            bearAnimator.SetBool(("bearDeath"), true);
        }
    }

    void Roll() //Method for rolling random material to playerboxes
    {
        //how to copy material and save it to a gameobject.
        //meshrenderer
        var box1color = materials.RandomItem();
        var box2color = materials.RandomItem();
        while (box1color.Equals(box2color))
        {
            box2color = materials.RandomItem();
        }
        player1Box.GetComponent<Renderer>().material = box1color;
        player2Box.GetComponent<Renderer>().material = box2color;
        Invoke("CheckPlayerBoxes",5.0f);
    }

    IEnumerator countDown()
    {
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
        }
        else
        {
            Debug.Log("Fail");
        }
    }
        
   }

public static class ArrayExtension
{
    //This is an extension method. RandomItem() will exist on all arrays
    public static T RandomItem<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
