using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LBar : MonoBehaviour {

	public Image currentLbar;
	public Text floodWarningText;
    public Inventory Inv;


	public float Lpoint = 50;
	private float maxLpoint = 100;

    private GameObject agua;
    private QMeter Q;

    private void Start()
	{
        agua = GameObject.FindGameObjectWithTag("Water");
        Q = FindObjectOfType<QMeter>();
        Inv = gameObject.GetComponent<Inventory>();
    }
	

	private void UpdateLbar()
	{
		float ratio = Lpoint / maxLpoint;
		currentLbar.rectTransform.localScale = new Vector3(1,ratio,1);
	}

	public void modifyL(float deltaL)
	{
		Lpoint += deltaL;
		if (Lpoint <= 0) {
			Lpoint = 0;
			Debug.Log ("Total Drought: L is negative");
            agua.GetComponent<QspriteSwitch>().setSprite(5);
        } else if (Lpoint > maxLpoint) {
            Lpoint = maxLpoint;
        }
        else
        {
            Q.setWaterSprite();
        }

		UpdateLbar ();
	}

	public void resetL()
	{
		Lpoint = maxLpoint;
		UpdateLbar ();
	}

    public void setL(float setting)
    {
        Lpoint = setting;
        Q.setWaterSprite();
        UpdateLbar();
    }




}
