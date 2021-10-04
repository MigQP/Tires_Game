using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class videoManager : MonoBehaviour {
    public bool leftHandOut;
    public bool rightHandOut;

    public GameObject theVideo;
    public Animator fader;

    public Image jugar;

    public Image creditos;

    public Image salir;

    public GameObject particleSys;

    public AudioSource theMusic;

    // Use this for initialization
    void Start () {
        theVideo.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
	    if( leftHandOut == true && rightHandOut == true )
        {
            fader.SetTrigger("FadeIn");
            theVideo.SetActive(true);
            jugar.enabled = false;
            creditos.enabled = false;
            salir.enabled = false;
            particleSys.SetActive(false);
            theMusic.volume = 0;
        }

        if (leftHandOut == false || rightHandOut == false)
        {
            theVideo.SetActive(false);
            jugar.enabled = true;
            creditos.enabled = true;
            salir.enabled = true;
            particleSys.SetActive(true);
            theMusic.volume = .9f;

        }




    }


   public void leftHandIn()
    {
        leftHandOut = false;
    }

   public void leftHandOutside()
    {
        leftHandOut = true;
    }

   public void rightHandIn()
    {
        rightHandOut = false;
    }

   public void rightHandOutside()
    {
        rightHandOut = true;
    }
}
