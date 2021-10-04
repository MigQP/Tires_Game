using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulloutTire : MonoBehaviour {

    public Collider tireCollider;
    public Collider jafCollider;


    public GameObject pullOutZone;

    public Animator theTire;

    public Animator jafLlanta;

    public int timesPulled;

    public bool hasPull;

    public int rin;

    public AudioSource pullSound;

    public GameObject pullHere;

	// Use this for initialization
	void Start () {
        pullOutZone = this.gameObject;
        jafCollider.enabled = false;

        pullSound = this.GetComponent<AudioSource>();

        pullHere.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if (this.gameObject.GetComponent<Collider>().enabled == true)
        {
            pullHere.SetActive(true);
        }
        else
        {
            pullHere.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        hasPull = true;
        if (other.gameObject.tag == "palanca")
        {
 
            jafLlanta.SetBool("palancear", true);
            timesPulled++;

        }
        
        if (timesPulled >= 2)
        {
        
            jafLlanta.SetBool("palancearMas", true);
          //  tireCollider.enabled = true;
            jafCollider.enabled = true;
        }

        if (timesPulled == 1)
        {
            pullSound.Play();
        }

        if (timesPulled == 2)
        {
            pullSound.Play();
        }

        hasPull = false; 
    }
}
