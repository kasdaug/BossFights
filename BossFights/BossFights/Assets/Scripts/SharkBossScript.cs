using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkBossScript : MonoBehaviour {

    private float HP = 100;
    private Animator sharkBossAnimator;
    public Rigidbody2D sharkRB { get; set; }
    public float WalkSpeed = 20f;
    private float JumpHeight = 500f;
    public Transform groundCheck;
    private bool Ground;

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody2D>().freezeRotation = true; //Remove the possibility of character tilt
        sharkRB = GetComponent<Rigidbody2D>();
        sharkBossAnimator = GetComponentInChildren<Animator>();
        sharkBossAnimator.SetBool("Idle", true);
        sharkBossAnimator.SetBool("Ground", true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Ground = sharkBossAnimator.GetBool("Ground");

    }
}
