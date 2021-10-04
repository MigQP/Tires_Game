using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponerPernos : MonoBehaviour {

    // INSERT SCREWS ON TIRE WITH SCREWDRIVER TOOL

    public bool hasBeenPut;

    private GameObject theHands;

    public GameObject thePerno;

    public AudioSource pernoClip;



    // Use this for initialization
    void Start () {
		theHands = GameObject.FindGameObjectWithTag("MainCamera");
        pernoClip = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "desatornillador")
        {
            if (hasBeenPut == false)
            {
                theHands.GetComponent<changeZones>().pernosPuestos++;
                pernoClip.Play();
            }
            hasBeenPut = true;

            thePerno.SetActive(true);

        }
    }
}
