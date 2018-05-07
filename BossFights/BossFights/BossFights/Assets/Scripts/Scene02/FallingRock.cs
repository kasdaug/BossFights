using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour {
    public Transform transform;
    public Vector3 vector;
    public float speed = 5;
    public GameObject[] lives;
    public GameObject target;
    public GameObject losePanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Time.deltaTime * vector * speed);
        if (transform.position.y<=-0.5)
        {
            if (lives[2].active)
            {
                Destroy(this.gameObject);
                lives[2].SetActive(false);
                lives[5].SetActive(true);
            }
            else if (lives[1].active)
            {
                Destroy(this.gameObject);
                lives[1].SetActive(false);
                lives[4].SetActive(true);
            }
            else
            {
                Destroy(this.gameObject);
                lives[0].SetActive(false);
                lives[3].SetActive(true);
                //Destroy(target);
                Time.timeScale = 0;
                losePanel.SetActive(true);
            }
        }
	}
}
