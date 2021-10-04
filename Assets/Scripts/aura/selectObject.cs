using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectObject : MonoBehaviour {

    public GameObject selectionAura;

	// Use this for initialization
	void Start () {
        selectionAura.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tiro")
        {
            selectionAura.SetActive(true);
     
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tiro")
        {
         selectionAura.SetActive(false);
        }
    }

}
