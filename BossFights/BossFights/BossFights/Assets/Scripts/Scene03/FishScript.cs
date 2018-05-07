using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

    public GameObject flyingFish;
    public Transform[] fishSpots;
    public float Timer = 5;

	// Use this for initialization
	void Start () {
        flyLittleFishes(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        int i = Random.Range(1, 3);

        Timer -= Time.deltaTime;
      //  Debug.Log(Timer);
        if(Timer <= 0)
        {
            flyLittleFishes(i);
            Timer = 5;
        }

       
    }

    void flyLittleFishes(int i)
    {
        Vector2 fishVector = new Vector2(0, 0);
        switch (i)
        {
            case 1:
                int j = Random.Range(-35, -20);
                fishVector = new Vector2(j, 30);
                GameObject fishFlying = (GameObject)Instantiate(flyingFish, fishSpots[0].position, Quaternion.identity);
                fishFlying.GetComponent<Rigidbody2D>().velocity = fishVector;
                Debug.Log("reached case 1");
                break;
            case 2:
                int k = Random.Range(-5, 5);
                fishVector = new Vector2(k, 30);
                GameObject fishFlying2 = (GameObject)Instantiate(flyingFish, fishSpots[1].position, Quaternion.identity);
                fishFlying2.GetComponent<Rigidbody2D>().velocity = fishVector;
                Debug.Log("reached case 2");
                break;
            case 3:
                fishVector = new Vector2(30, 30);
                GameObject fishFlying3 = (GameObject)Instantiate(flyingFish, fishSpots[2].position, Quaternion.identity);
                fishFlying3.GetComponent<Rigidbody2D>().velocity = fishVector;
                Debug.Log("reached case 3");
                break;
        }
    }

    void onTriggerEnter2d(Collider2D col)
    {
        if (col.gameObject.tag == "FishNet")
        {
            flyingFish.transform.Translate(new Vector2(0, 0));
            Debug.Log("Fish Hit Net");
        }
    }
}
