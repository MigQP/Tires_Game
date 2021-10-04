using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpTire : MonoBehaviour {
    public Pressometer inflateZone;
    public scaleLerper increase;


    private AudioSource inflateSound;

    private Collider inflCol;

    public GameObject inflateHere;

	// Use this for initialization
	void Awake () {
		inflateZone = GameObject.Find("Puntero").GetComponent<Pressometer>();
     //   increase = (scaleLerper)FindObjectOfType(typeof(scaleLerper));
        inflateSound = GameObject.FindGameObjectWithTag("pump").GetComponent<AudioSource>();

        inflCol = this.GetComponent<Collider>();
        inflateHere.SetActive(false);
    }

    
	
	// Update is called once per frame
	void Update () {
        increase = (scaleLerper)FindObjectOfType(typeof(scaleLerper));


        if (inflCol.enabled == false)
        {
            inflateSound.Stop();
        }

        if (this.gameObject.GetComponent<Collider>().enabled == true)
        {
            inflateHere.SetActive(true);
        }
        else
        {
            inflateHere.SetActive(false);
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "inflador")
        {
            inflateZone.isPumping = true;

            increase.StartLerping();

            if (inflateSound.isPlaying == false)
            {
                inflateSound.Play();
            }
            if (inflateSound.isPlaying == true)
            {
                inflateSound.UnPause();
            }
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "inflador")
        {
            inflateZone.isPumping = false;

            increase.shouldLerp = false;

            inflateSound.Pause();
        }
    }
}

