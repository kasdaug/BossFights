using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour {

    public GameObject flyingFish;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.forward, 360*Time.deltaTime * -1);
            Debug.Log("We get rótation");
        }
	}

    void onTriggerEnter2D(Collider2D fishy)
    {
        if(fishy.gameObject.tag == "FlyingFish")
        {
            Debug.Log("This is fishy!");
        }
    }
}
