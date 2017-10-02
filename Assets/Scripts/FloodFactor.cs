using UnityEngine;
using System.Collections;

public class FloodFactor : MonoBehaviour {

	//flood factor starts out negligible
	public int FF = 0;

	public void modifyFF(int deltaFF)
	{
		//Debug.Log ("Initial FF: " + FF);

		FF += deltaFF;

		//Debug.Log ("New FF: " + FF);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
