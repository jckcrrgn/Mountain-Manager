using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySpriteSwitch : MonoBehaviour {

    public Sprite[] array = new Sprite[3];


    private int rainfall;


    // Use this for initialization
    void Start()
    {
        rainfall = GameObject.FindWithTag("GameController").GetComponent<NextTurn>().thisSeasonsRainfall;
    }

    

    public void setSprite(int spriteIndex)
    {
        GetComponent<SpriteRenderer>().sprite = array[spriteIndex];
    }

}
