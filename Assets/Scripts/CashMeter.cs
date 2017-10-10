using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashMeter : MonoBehaviour {

	public Text moneyText;

	public int currentCash = 10000;

	// Use this for initialization
	void Start () {
		UpdateCashMeter ();
	}

	private void UpdateCashMeter()
	{
		moneyText.text = "$" + currentCash.ToString ("n0");
	}

	public void spend(int cost)
	{
		currentCash -= cost;
		UpdateCashMeter ();
	}

	public void deposit(int payment)
	{
		currentCash += payment;
		UpdateCashMeter ();
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
