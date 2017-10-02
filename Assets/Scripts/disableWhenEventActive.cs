using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableWhenEventActive : MonoBehaviour {

    public GameObject eventPopup;

	// Use this for initialization
	void Start () {
        //eventPopup = GameObject.FindWithTag("Event");
	}
	
	// Update is called once per frame
	void Update () {
        if (eventPopup.activeSelf)
        {
            gameObject.SetActive(false);
        }
	}
}
