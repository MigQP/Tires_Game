using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insertReplace : MonoBehaviour {

    public Collider rinCollider;


    public Collider inTireCollider;

    public Collider theFr;

    bool canPut;

    // Use this for initialization
    void Start () {
        rinCollider = GameObject.FindGameObjectWithTag("rin").GetComponent<Collider>();

        rinCollider.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
   
        if (canPut)
        {
            rinCollider.enabled = true;
            inTireCollider.enabled = true;
            theFr.enabled = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "llantaOriginal")
        {
            canPut = true;
            rinCollider.enabled = true;
            theFr.enabled = true;
        }

        if (other.gameObject.tag == "llantaRepuesto")
        {
            canPut = true;
        }

     
    }
}
