using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraFold : MonoBehaviour {

    // SELECTION OBJECT TO GIVE FEEDBACK WHEN OBJECT IS GRABBABLE

    public GameObject grabAura;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnAura()
    {
    
        grabAura.SetActive(true);
       
    }

    public void OutAura()
    {
        grabAura.SetActive(false);
    }

     void OnCollisionEnter(Collision collision)
    {
     
    }
}
