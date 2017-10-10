using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLast8QValues : MonoBehaviour {

    //every turn, record the current QGrade
    //if QGrade is >90 for 8 turns, display THRIVING sprite

    //this list will store the last Q values for the last 8 turns
    public List<int> Qrecord = new List<int>();

    //we will need access to QGrade
    public QMeter QMeter;

    //the number of values we're tracking
    public int numberOfValuesToTrack = 8;

    //we need the THRIVING sprite
    public GameObject thrivingSprite;
    public int NumberOfGoodSeasonsNecessaryToThrive;
    public int minimumThrivingGrade;



	// Use this for initialization
	void Start () {
        QMeter = gameObject.GetComponent<QMeter>();

        //set the thriving sprite inactive
        thrivingSprite.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addValue()
    {
        Qrecord.Add(QMeter.Qgrade);

        if(Qrecord.Count > numberOfValuesToTrack)
        {
            Qrecord.RemoveAt(0);
        }

        //if (Qrecord[Qrecord.Count - 1] > 90 && Qrecord[Qrecord.Count - 2]>90)
        //{
        //    displayThrivingSprite();
        //}
        //else
        //{
        //    thrivingSprite.SetActive(false);
        //}

        for(var i=1; i<=NumberOfGoodSeasonsNecessaryToThrive; i++)
        {
            if (Qrecord[Qrecord.Count - i] >= minimumThrivingGrade && i!=NumberOfGoodSeasonsNecessaryToThrive)
            {
                continue;
            }
            else if(i==NumberOfGoodSeasonsNecessaryToThrive && Qrecord[Qrecord.Count - i] >= minimumThrivingGrade && QMeter.Qgrade>=minimumThrivingGrade)
            {
                thrivingSprite.SetActive(true);
            }else
            {
                thrivingSprite.SetActive(false);
                break;
            }
            
        }
        
    }

    public void displayThrivingSprite()
    {
        thrivingSprite.SetActive(true);
    }
}
