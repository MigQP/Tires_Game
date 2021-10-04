using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class stayrTire : MonoBehaviour {

    public Rigidbody jafWeight;
    public InteractionBehaviour j_grb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {

            j_grb.enabled = false;
            jafWeight.isKinematic = true;

        }
    }
}
