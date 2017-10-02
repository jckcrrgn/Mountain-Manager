using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //boolean has/hasNot for every possible structure
    public bool hasResort = false;
    //perTurnPollution for each building
    //note that pollution is modified by INT, and Q has a range of 50-100
    public int resortPerTurnPollution=20;
    //perTurnConsumption for each building
    //note that Lbar is modified by FLOAT, and L has a range of 0-100
    public float resortPTC=20f;

    public bool hasPreserve = false;
    public int preservePTP;
    public float preservePTC;

    public bool hasGravelParking = false;
    public int gravParkingPTP;
    public float gravParkingPTC;

    public bool hasPavedParking = false;
    public int paveParkingPTP;
    public float paveParkingPTC;

    public bool hasCampground = false;
    public int campgroundPTP;
    public float campgroundPTC;

    //UI PTP & PTC
    public Text PTPtext;
    public Text PTCtext;


    // Use this for initialization
    void Start () {
        resortPerTurnPollution = 20;
        resortPTC = 20f;
        preservePTP = -5;
        preservePTC = 0f;
        gravParkingPTP = 5;
        gravParkingPTC = 0f;
        paveParkingPTP = 10;
        paveParkingPTC = 0f;
        campgroundPTP = 5;
        campgroundPTC = 5f;

        PTCtext = GameObject.Find("PTP").GetComponent<Text>();
        PTPtext = GameObject.Find("PTC").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        UIptp();
        UIptc();
	}

    public void setCampground(bool setting)
    {
        hasCampground = setting;
        Debug.Log("Campground: " + hasCampground);
    }

    public void setPavedParking(bool setting)
    {
        hasPavedParking = setting;
        Debug.Log("PavedParking: " + hasPavedParking);
    }

    public void setGravelParking(bool setting)
    {
        hasGravelParking = setting;
        Debug.Log("Gravel Parking: " + hasGravelParking);
    }

    public void setResort(bool setting)
    {
        hasResort = setting;
        Debug.Log("Resort: "+hasResort);
    }

    public void setPreserve(bool setting)
    {
        hasPreserve = setting;
        Debug.Log("Preserve: " + hasPreserve);
    }

    public int totalPTP()
    {
        int total=0;

        if (hasResort)
        {
            total += resortPerTurnPollution;
        }
        if (hasPreserve)
        {
            total += preservePTP;
        }
        if (hasPavedParking)
        {
            total += paveParkingPTP;
        }
        if (hasGravelParking)
        {
            total += gravParkingPTP;
        }
        if (hasCampground)
        {
            total += campgroundPTP;
        }
        //Debug.Log("PTP: " + total);
        return total;
    }

    public float totalPTC()
    {
        float total = 0f;

        if (hasResort)
        {
            total += resortPTC;
        }
        if (hasPreserve)
        {
            total += preservePTC;
        }
        if (hasPavedParking)
        {
            total += paveParkingPTC;
        }
        if (hasGravelParking)
        {
            total += gravParkingPTC;
        }
        if (hasCampground)
        {
            total += campgroundPTC;
        }
        //Debug.Log("PTC: " + total);
        return total;
    }

    public void UIptp()
    {
        PTPtext.text = "Per Turn Pollution: "+totalPTP().ToString();
    }

    public void UIptc()
    {
        PTCtext.text = "Per Turn Consumption: " + totalPTC().ToString();
    }
}
