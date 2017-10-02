using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTurn : MonoBehaviour {
    /*things
     * 
     * int turn
     * int floodfactor
     * int rainfall
     * text TURNtext
     * text RAINFALLtext
     * 
    //things to do
     *
     * increment turn
     * calculateRainfall
     * doesItFlood
     * calculatePollution
     * calculateConsumption
     * 
     */

    public int turn;
    public int floodfactor;
    public int thisSeasonsRainfall;
    public SkySpriteSwitch SkySwitch;
    public LBar L;
    public Inventory inv;
    public QMeter Q;
    public Text TURNtext;
    public Text RAINFALLtext;

    //thing: floodSpriteArray
    public Sprite[] floodSpriteArray;
    public SpriteRenderer floodRenderer;

    private System.Random r = new System.Random();
    


    // Use this for initialization
    void Start () {
        turn = 0;
        SkySwitch = GameObject.FindGameObjectWithTag("SkyWater").GetComponent<SkySpriteSwitch>();
        L = GameObject.FindGameObjectWithTag("GameController").GetComponent<LBar>();
        inv = gameObject.GetComponent<Inventory>();
        Q = gameObject.GetComponent<QMeter>();
        TURNtext = GameObject.Find("Turn#").GetComponent<Text>();
        RAINFALLtext = GameObject.Find("Rainfall").GetComponent<Text>();
        floodSpriteArray = GameObject.FindGameObjectWithTag("FloodWater").GetComponent<floodWaterSprites>().floodSpritesArray;
        floodRenderer = GameObject.FindGameObjectWithTag("FloodWater").GetComponent<SpriteRenderer>();

        //start with this button inactive
        //this.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        currentYearAndSeasonUI();
	}

    private void FixedUpdate()
    {
        floodfactor = gameObject.GetComponent<FloodFactor>().FF;
    }

    public void incrementTurn()
    {
        turn += 1;
        Debug.Log("Turn: " + turn);
    }

    public void calculateRainfall()
    {
        thisSeasonsRainfall = r.Next(0, 100);
        Debug.Log("This season's rainfall: " + thisSeasonsRainfall);
        //return thisSeasonsRainfall;
        if (doesItFlood())
        {
            Debug.Log("flood, y'all");
            if (inv.hasResort)
            {
                setFloodSprite(1);
            }else if (inv.hasPreserve)
            {
                setFloodSprite(2);
            }
            else
            {
                setFloodSprite(3);
            }
        }
        else
        {
            setFloodSprite(0);
        }

        if (thisSeasonsRainfall < 33)
        {
            setRainSprite(0);
            //modifyWaterL(5f);
        }else if (thisSeasonsRainfall < 50)
        {
            setRainSprite(1);
            //modifyWaterL(15f);
        }
        else
        {
            setRainSprite(2);
            //modifyWaterL(25f);
        }

        modifyWaterL(rainfallToFloat(thisSeasonsRainfall)*1f);

        rainfallUI();

    }

    public void setRainSprite(int spriteIndex)
    {
        SkySwitch.setSprite(spriteIndex);
    }

    public void modifyWaterL(float delta)
    {
        L.modifyL(delta);
    }

    public bool doesItFlood()
    {
        //if rainfall is greater than 100-FF, flood
        if (thisSeasonsRainfall > (100 - floodfactor))
        {
            Debug.Log(thisSeasonsRainfall + " vs " + (100 - floodfactor) + " flood dampening = flood");
            return true;
        }
        else
        {
            Debug.Log(thisSeasonsRainfall + " vs " + (100 - floodfactor) + " flood dampening = no flood");
            return false;
        }
    }

    private float rainfallToFloat(int rainfall)
    {
        return (float)rainfall;
    }

    public void modifyLUsingPTC()
    {
        modifyWaterL(-inv.totalPTC());
        Debug.Log("Lpoint: "+L.Lpoint);
    }

    public void modifyQUsingPTP()
    {
        Q.pollute(inv.totalPTP());
    }

    public void addRainfallToL(int rainfall)
    {
        float f = (float)rainfall;
        L.modifyL(rainfall);
        Debug.Log("Added rainfall: " + f);
    }

    public void currentYearAndSeasonUI()
    {
        string season = null;
        int year;

        //convert the turn number into the correct season
        //0,4,8,12,16 = spring
        if (turn == 0 || turn % 4 == 0)
        {
            season = "Spring";
        } else if (turn == 1 || turn % 4 == 1)
        {
            season = "Summer";
        } else if (turn == 2 || turn % 4 == 2)
        {
            season = "Fall";
        } else if (turn == 3 || turn % 4 == 3)
        {
            season = "Winter";
        }
        else { Debug.Log("Your season converter for the UI turn display is fucky, m8 :(");}

        //determine the year
        year = turn / 4;

        //display as form "Winter 3"
        TURNtext.text = "Year "+year.ToString() +" ("+ season + ")";
    }

    public void rainfallUI()
    {
        RAINFALLtext.text = "Precipitation: "+thisSeasonsRainfall.ToString()+" inches/season";
    }

    public void setFloodSprite(int spriteIndex)
    {
        floodRenderer.sprite = floodSpriteArray[spriteIndex];
    }
}
