using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class displayEvent : MonoBehaviour {

    //things
    //EventOBJ
    //EventMessage
    //EventOption1Text
    //EventOption2Text
    //

    public GameObject EventOBJ;
    public Text EventMessage;
    public Text EventOption1Text;
    public Text EventOption2Text;
    public Button button1;
    public Button button2;

    public CashMeter bank;
    public QMeter Q;
    

    //we need the Event class
    public Event eventClass;
    //and the Event Deck
    public List<Event> eventDeck;

    // Use this for initialization
    void Start () {
        EventOBJ = GameObject.FindGameObjectWithTag("Event");
        EventMessage = EventOBJ.transform.Find("Message").GetComponent<Text>();
        EventOption1Text = EventOBJ.transform.Find("Button").GetComponentInChildren<Text>();
        EventOption2Text = EventOBJ.transform.Find("Button (1)").GetComponentInChildren<Text>();
        eventClass = gameObject.GetComponent<Event>();

        //set up the Event Deck
        eventDeck = new List<Event>();
        fillEventDeck();
        

        //turn the Event popup off until needed
        EventOBJ.SetActive(false);

        bank = gameObject.GetComponent<CashMeter>();
        Q = gameObject.GetComponent<QMeter>();


    }
	
	// Update is called once per frame
	void Update () {

        
    }

    private void fillEventDeck()
    {
        eventDeck.Add(new Event("There has been a landslide!", "Pay for cleanup", "Eh", -5000, 20));
        eventDeck.Add(new Event("Algal Bloom!", "Pay for cleanup", "Eh", -10000, 20));
        eventDeck.Add(new Event("Nub Nubs the squirrel has become internet famous!", "Bask in increased tourism", "Put a price on Nub Nubs's head", 10000));
        eventDeck.Add(new Event("A new species of beautiful birds arrive. They are reportedly delicious when grilled over" +
            " local tree bark.","Watch the birds","Eat the birds",0,0));
    }

    public void pickAnEventCard()
    {
        Event pickedCard = eventDeck[Random.Range(0, eventDeck.Count)];
        updateEventPopup(pickedCard);
    }

    public bool RollWithHitChanceOf(int percentChance)
    {
        if (percentChance > 100 || percentChance < 0)
        {
            Debug.Log("Illogical Roll Chance in displayEvent.cs");
            return false;
        }
        else
        {
            var roll = Random.Range(0, 100);
            if (roll <= percentChance)
            {
                Debug.Log("Hit");
                return true;
            }
            else
            {
                Debug.Log("Miss");
                return false;
            }
        }
    }

    public void doesAnEventHappen(int likelihood)
    {
        if (RollWithHitChanceOf(likelihood))
        {
            pickAnEventCard();
            EventOBJ.SetActive(true);
        }
    }

    private void updateEventPopup(Event currentCard)
    {
        EventMessage.text = currentCard.EventText;
        EventOption1Text.text = currentCard.button1Text;
        EventOption2Text.text = currentCard.button2Text;


        //THIS IS A THING. IT SHOULD BE IT'S OWN METHOD. NAMED AFTER THE THING.
        button1.onClick.AddListener(delegate { bank.deposit(currentCard.button1MoneyConsequence); });
        button2.onClick.AddListener(delegate { Q.pollute(currentCard.button2QConsequence); });
    }

    //public void addButtonClickFunction(Button whichButton, functionAndConsequence)
    //{

    //}
}
