using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;

public class grabTire : MonoBehaviour {

    // WHEN BOTH HANDS ON TIRE, IS POSSIBLE TO GRAB IT 


    public Animator actualTire;
    public Rigidbody tireWeight;

    public InteractionBehaviour theGrab;


    public bool handLeftColliding;
    public bool handRightColliding;

    private Transform endPoint;
    public Collider theTire;

    public GameObject grabSignal;

    // Use this for initialization
    void Start () {
        actualTire = this.GetComponent<Animator>();
        tireWeight = GetComponent<Rigidbody>();
        endPoint = this.transform;
        theTire = this.gameObject.GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (tireWeight.angularDrag == 0)
        {
            actualTire.enabled = false;
        }

        if (handLeftColliding && handRightColliding == true)
        {
            grabSignal.SetActive(true);
            theGrab.ignoreGrasping = false;

        }

   

    }

    void OnTriggerEnter(Collider other)
    {
     //   if (n == 2)
     //       theGrab.ignoreGrasping = false;

       if (other.gameObject.tag == "manoIzq")
        {
         
                handLeftColliding = true;
        }

        if (other.gameObject.tag == "manoDer")
        {
            handRightColliding = true;
        }

        if (other.gameObject.tag == "palanca")
        {
            handLeftColliding = false;
            handRightColliding = false;
        }

        if (other.gameObject.tag == "Finish")
        {
            
            theGrab.enabled = false;
            tireWeight.isKinematic = true;
            StartCoroutine("theEraser");
        }
    }

    void OnTriggerExit(Collider other)
    {
     

        if (other.gameObject.tag == "manoIzq")
        {
          
            handLeftColliding = false;
        }

        if (other.gameObject.tag == "manoDer")
        {
            grabSignal.SetActive(false);
            handRightColliding = false;
        }
    }

    IEnumerator theEraser ()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }


}
   

