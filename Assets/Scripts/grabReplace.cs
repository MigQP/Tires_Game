using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;

public class grabReplace : MonoBehaviour {

    // RESTART TIRE IF MISSING


    public Animator thisTire;

    public bool handLeftColliding;
    public bool handRightColliding;

    public InteractionBehaviour theGrab;

    private Rigidbody replaceWeight;

    public GameObject tire;

   

    public Collider inflar;

    // Use this for initialization
    void Awake () {

        replaceWeight = GetComponent<Rigidbody>();
        inflar = GameObject.FindGameObjectWithTag("inflar").GetComponent<Collider>();
       

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (replaceWeight.angularDrag == 0)
        {
            thisTire.enabled = false;
        }


        if (handLeftColliding && handRightColliding == true)
        {
            theGrab.ignoreGrasping = false;

        }

      

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "manoIzq")
        {

            handLeftColliding = true;
        }

        if (other.gameObject.tag == "manoDer")
        {

            handRightColliding = true;
        }

        if (other.gameObject.tag == "rin")
        {
            theGrab.enabled = false;
        //    this.gameObject.SetActive(false);
            inflar.enabled = true;

            thisTire.enabled = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

            StartCoroutine("Fade");
          
        }
    }

    void OnTriggerExit (Collider other)
    {

        if (other.gameObject.tag == "manoIzq")
        {

            handLeftColliding = false;
        }

        if (other.gameObject.tag == "manoDer")
        {

            handRightColliding = false;
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(.15f);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
