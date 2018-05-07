using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour {
    public bool robotIsDead;
    public bool pumpkinIsDead;
    public bool sharkIsDead;
    public GameObject winPanel;
    public GameObject losePanel;

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Play("levelMusic");
    }
	
	// Update is called once per frame
	void Update () {
        if (sharkIsDead)
        {
            winPanel.SetActive(true);
        }
		if (robotIsDead || pumpkinIsDead)
        {
            losePanel.SetActive(true);
        }
	}
}
