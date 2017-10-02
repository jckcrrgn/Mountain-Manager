using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupMenu : MonoBehaviour {


	public GameObject window;
	public Text messageField;


    //Displays the given message in a pop-up
    public void Show(){
		//messageField.text = message;
		window.SetActive (true);
	}

	//Closes the pop-up
	public void Hide(){
		window.SetActive (false);
	}

	public void Quit(){
		Application.Quit ();
	}

    
}
