using UnityEngine;
using System.Collections;

public class QspriteSwitch : MonoBehaviour {
	
	public Sprite[] array = new Sprite[5];
	
	private int index = 0;


	private int qGrade;
	
	
	// Use this for initialization
	void Start () {
		qGrade = GameObject.FindWithTag ("GameController").GetComponent<QMeter> ().Qgrade;
	}
	
	public void nextSprite()
	{
		fetchQGrade ();
		index++;
		
		if (index > (array.Length-1)) {
			index=(array.Length-1);
		}
		GetComponent<SpriteRenderer>().sprite = array [index];

		Debug.Log ("QSwitch knows the Qgrade is: " + qGrade);
	}
	
	public void previousSprite()
	{
		index--;
		
		if (index < 0) {
			index=0;
		}
		GetComponent<SpriteRenderer>().sprite = array [index];
	}

	public void setSprite(int spriteIndex){
		GetComponent<SpriteRenderer>().sprite = array [spriteIndex];
	}

	private void fetchQGrade(){
		qGrade = GameObject.FindWithTag ("GameController").GetComponent<QMeter> ().Qgrade;
	}
}
