using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slt : MonoBehaviour {


    /*INSERTION OF TIRE WITHIN TRUCK */

    public Animator thisTireee;

    public MeshRenderer musli;

    

    // Use this for initialization
    void Start () {
		
        musli.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.z != -5.606f)
            musli.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "llantaRepuesto")
        {
            musli.enabled = true;
            thisTireee.SetBool("hasEntered", true);
      
        }
    }

    private void OnTriggerExit(Collider other)
    {

        musli.enabled = false;
    }
}
