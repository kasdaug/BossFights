using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {
    public bool robotIsDead = false;
    public bool pumpkinIsDead = false;
    public bool pandaIsDead = false;
    public GameObject winPanel;
    public GameObject losePanel;

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Play("levelMusic");
    }
	
	// Update is called once per frame
	void Update () {
        if (pandaIsDead)
        {
            winPanel.SetActive(true);
        }
		if (robotIsDead && pumpkinIsDead)
        {
            losePanel.SetActive(true);
        }
	}
}
