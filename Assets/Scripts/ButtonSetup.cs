using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetup : MonoBehaviour {

    public GameObject buildButton;
    public GameObject nextTurnButton;

	// Use this for initialization
	void Start () {
        buildButton = GameObject.Find("Button (Build)");
        nextTurnButton = GameObject.Find("Button (nextTurn)");

        nextTurnButton.SetActive(false);
        buildButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
