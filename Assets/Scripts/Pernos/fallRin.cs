using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallRin : MonoBehaviour {

    private Rigidbody thePerno;

    private GameObject thePlayer;

    public bool hasEntered;

    private AudioSource audioPernoClip;

    public AudioClip drillSound;
    public AudioClip dropSound;

    // Use this for initialization
    void Start() {
        thePerno = this.gameObject.GetComponent<Rigidbody>();
        thePlayer = GameObject.FindGameObjectWithTag("MainCamera");
        audioPernoClip = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "desatornillador")
        {
            if (hasEntered == false)
            {
                audioPernoClip.clip = drillSound;
                audioPernoClip.Play();
                thePlayer.GetComponent<changeZones>().rinesAfuera++;
        
            }
            hasEntered = true;
            thePerno.useGravity = true;
            thePerno.isKinematic = false;

           
        }
    }

        void OnCollisionEnter(Collision collision)
    {

        audioPernoClip.clip = dropSound;
        audioPernoClip.Play();
    }
}
