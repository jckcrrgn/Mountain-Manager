using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floodWaterSprites : MonoBehaviour {

    //things
    /*
     * spriteArray
     * */
    public Sprite[] floodSpritesArray = new Sprite[4];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setSprite(int index)
    {
        GetComponent<SpriteRenderer>().sprite = floodSpritesArray[index];
    }
}
