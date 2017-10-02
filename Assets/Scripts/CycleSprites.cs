using UnityEngine;
using System.Collections;

public class CycleSprites : MonoBehaviour {

	public Sprite[] array = new Sprite[4];

	private int index = 0;



	// Use this for initialization
	void Start () {
	}

	public void nextSprite()
	{
		index++;

		if (index > (array.Length-1)) {
			index=0;
		}
		GetComponent<SpriteRenderer>().sprite = array [index];
	}

	public void previousSprite()
	{
		index--;
		
		if (index < 0) {
			index=(array.Length-1);
		}
		GetComponent<SpriteRenderer>().sprite = array [index];
	}
}
