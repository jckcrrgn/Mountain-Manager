using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuInvCheck : MonoBehaviour {

    /* Things
     * 
     * Manager Inventory
     * campsiteOption
     * resortOption
     * preserveOption
     * parkingOption
     * 
     * Things to Do
     * 
     * SetActive buildMenu options, based on inventory
     */

    public Inventory inventory;

	// Use this for initialization
	void Start () {
        inventory = gameObject.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setBuildMenuOptions()
    {


    }
}
