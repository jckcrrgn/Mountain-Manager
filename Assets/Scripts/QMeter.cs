using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QMeter : MonoBehaviour {

	public Image currentQ;
	public int Qgrade = 100;

    public LBar waterL;



	private int Qmax = 100;
	private int Qmin = 50;

//	private float QcolorR;
//	private float QcolorB;
//	private float QcolorG;
//	private float QcolorA;

	private GameObject agua;



	// Use this for initialization
	void Start () {
        //		QcolorR = currentQ.color.r;
        //		QcolorB = currentQ.color.b;
        //		QcolorG = currentQ.color.g;
        //		QcolorA = currentQ.color.a;
        waterL = gameObject.GetComponent<LBar>();

		agua = GameObject.FindGameObjectWithTag ("Water");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void fullCleanQ()
	{
		agua.GetComponent<QspriteSwitch>().setSprite (0);
		Qgrade = Qmax;
	}
	
	public void pollute(int deltaQ)
	{

		if (deltaQ == null) {
			//subtract a grade from the Qgrade
			Qgrade -= 10;
		} else {
			Qgrade-=deltaQ;
		}

        //but make sure it doesn't drop below 50
        if (Qgrade > Qmax)
        {
            Qgrade = Qmax;
        }
        if (Qgrade < Qmin) {
			Qgrade=Qmin;
		}
        if (waterL.Lpoint <= 0)
        {
            return;
        }
        else if(Qgrade > 90)
        {
            agua.GetComponent<QspriteSwitch>().setSprite(0);
        }else if(Qgrade > 80)
        {
            agua.GetComponent<QspriteSwitch>().setSprite(1);
        }else if (Qgrade > 70)
        {
            agua.GetComponent<QspriteSwitch>().setSprite(2);
        }
        else if (Qgrade > 60)
        {
            agua.GetComponent<QspriteSwitch>().setSprite(3);
        }
        else if (Qgrade >= 50)
        {
            agua.GetComponent<QspriteSwitch>().setSprite(4);
        }
        else
        {
            Debug.Log("Failure of Q if/else");
        }

  //      switch (Qgrade) {
		//case 100:
		//	agua.GetComponent<QspriteSwitch>().setSprite (0);
		//	break;
		//case 90:
		//	agua.GetComponent<QspriteSwitch>().setSprite (1);
		//	break;
		//case 80:
		//	agua.GetComponent<QspriteSwitch>().setSprite (2);
		//	break;
		//case 70:
		//	agua.GetComponent<QspriteSwitch>().setSprite (3);
		//	break;
		//case 60:
		//	agua.GetComponent<QspriteSwitch>().setSprite (4);
		//	break;
		//default:
		//	Debug.Log("Failure of QMeter's switch statement");
		//	break;
		//}




		//agua.GetComponent<QspriteSwitch>().nextSprite ();


//		currentQ.color = new Color (QcolorR+deltaQ, QcolorG, QcolorB-deltaQ, QcolorA);
//
//		if (currentQ.color.r > 1f) {
//			Color temp = currentQ.color;
//			temp.r=1f;
//			currentQ.color=temp;
//		}
//		if(currentQ.color.b<0f){
//			Color temp = currentQ.color;
//			temp.b=0f;
//			currentQ.color=temp;
//		}
//
//		QcolorR = currentQ.color.r;
//		QcolorB = currentQ.color.b;
//		QcolorG = currentQ.color.g;
//		QcolorA = currentQ.color.a;
//
//		Debug.Log ("Q Grade = "+Qgrade);
	}

	public void cleanUp(int deltaQ)
	{
		if (deltaQ == null) {
			//add a grade to the Qgrade
			Qgrade += 10;
		} else {
			Qgrade+=deltaQ;
		}

		//but make sure it doesn't drop below 40
		if (Qgrade > Qmax) {
			Qgrade=Qmax;
		}

		switch (Qgrade) {
		case 100:
			agua.GetComponent<QspriteSwitch>().setSprite (0);
			break;
		case 90:
			agua.GetComponent<QspriteSwitch>().setSprite (1);
			break;
		case 80:
			agua.GetComponent<QspriteSwitch>().setSprite (2);
			break;
		case 70:
			agua.GetComponent<QspriteSwitch>().setSprite (3);
			break;
		case 60:
			agua.GetComponent<QspriteSwitch>().setSprite (4);
			break;
		default:
			Debug.Log("Failure of QMeter's switch statement");
			break;
		}

        

		//agua.GetComponent<QspriteSwitch>().previousSprite ();

//		//down the R, up the B of Q's color RGB
//		currentQ.color = new Color (QcolorR-deltaQ, QcolorG, QcolorB+deltaQ, QcolorA);
//
//		//prevent R from going negative 
//		if (currentQ.color.r < 0f) {
//			Color temp = currentQ.color;
//			temp.r=0f;
//			currentQ.color=temp;
//		}
//
//		//prevent the B from exceeding 1
//		if(currentQ.color.b>1f){
//			Color temp = currentQ.color;
//			temp.b=1f;
//			currentQ.color=temp;
//		}
//		
//		QcolorR = currentQ.color.r;
//		QcolorB = currentQ.color.b;
//		QcolorG = currentQ.color.g;
//		QcolorA = currentQ.color.a;
//
//		Debug.Log ("Q Grade = "+Qgrade);
	}

    public void setWaterSprite()
    {
        switch (Qgrade)
        {
            case 100:
                agua.GetComponent<QspriteSwitch>().setSprite(0);
                break;
            case 90:
                agua.GetComponent<QspriteSwitch>().setSprite(1);
                break;
            case 80:
                agua.GetComponent<QspriteSwitch>().setSprite(2);
                break;
            case 70:
                agua.GetComponent<QspriteSwitch>().setSprite(3);
                break;
            case 60:
                agua.GetComponent<QspriteSwitch>().setSprite(4);
                break;
            default:
                Debug.Log("Failure of QMeter's switch statement");
                break;
        }
    }
}
