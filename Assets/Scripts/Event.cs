using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour {

    //things
    /*
     * EventText
     * 1buttonText
     * 2buttonText
     * button1MoneyConsequence
     * button2QConsequence
     *
     * 
     */
    public string EventText;
    public string button1Text;
    public string button2Text;
    public int button1MoneyConsequence;
    public int button2QConsequence;
    

    public Event(string maintext, string button1txt, string button2txt, int button1Money=0, int button2Q=0)
    {
        EventText = maintext;
        button1Text = button1txt;
        button2Text = button2txt;
        button1MoneyConsequence = button1Money;
        button2QConsequence = button2Q;
        

    }

	// Use this for initialization
	void Start () {
        //createEventDeck();
        
        //button1 = GameObject.FindGameObjectWithTag("Event").transform.Find("Button").GetComponent<Button>();
        //Debug.Log("button1 is: "+button1);
        //button2 = GameObject.FindGameObjectWithTag("Event").transform.Find("Button (1)").GetComponent<Button>();

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void createEventDeck()
    //{
    //    //make a list to add events to
    //    public List<Event> eventDeck = new List<Event>();
    //}
}
