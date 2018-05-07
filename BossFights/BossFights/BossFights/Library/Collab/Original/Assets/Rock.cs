using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    private Rigidbody2D rockRB;


    // Use this for initialization
    void Start()
    {
        rockRB = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //rockRB.AddForce(2, 3);
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log("Collision");

        if(col.gameObject.tag == "Player1")
        {
            rockRB.AddForce(new Vector2(1300, 2));
            Debug.Log("Player hit rock");
            transform.gameObject.tag = "RockHitByPlayer";
        }
        if (col.gameObject.tag == "Player2")
        {
            rockRB.AddForce(new Vector2(-300, 2));
            Debug.Log("Player2 Hit rock");
            transform.gameObject.tag = "RockHitByPlayer";
        }

        if(col.gameObject.tag == "Boss" && gameObject.tag == "RockHitByPlayer")
        {
            GameObject.Find("PandaBoss").GetComponent<PandaBoss>().DecreaseHealth();
            Debug.Log("rock hit by boss");
            transform.gameObject.tag = "Rock";
        }

        if(col.gameObject.tag == "Boss" && gameObject.tag == "Rock")
        {
            transform.Translate(new Vector2(Random.Range(1, 10), Random.Range(5, 20) * Time.deltaTime));
         
        }
    }
}
