using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtonPopup : MonoBehaviour
{

    /*things*/
    /*
		button
		pop-up menu
		menu options
	*/
    /*things to do*/
    /*
		display popup
	*/

    public GameObject window;
    public Text messageField;
    public GameObject popup;

    // Use this for initialization
    void Start()
    {
        popup = GameObject.FindWithTag("PopMenu");
        popup.SetActive(false);
    }

    //Displays the given message in a pop-up
    public void Show()
    {
        //messageField.text = message;
        window.SetActive(true);
    }

    //Closes the pop-up
    public void Hide()
    {
        window.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DisplayPopup()
    {
        if (!popup.activeInHierarchy)
        {
            popup.SetActive(true);
        }
        else
        {
            popup.SetActive(false);
        }

    }
}
