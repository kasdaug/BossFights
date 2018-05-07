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

    public GameObject[] boxes; 

	// Use this for initialization
	void Start () {
        bearAnimator = GetComponentInChildren<Animator>();
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

        
    }

    void CountDown()    //method to countdown for placement
    {
        int i = 0;
        counterText.text = ("" + i);
    }

    void CheckPlayerBoxes() //method to check if players are in the correct boxes
    {

    }
        
   }
