using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class changeZones : MonoBehaviour {

    public Animator thePlayer;
    private Animator handGesture;
    private Animator gotoGameZone;

    public bool inGameZone;

    public Transform playerPosition;

    public int rinesAfuera;

    public int pernosPuestos;

    public GameObject tireEject;

    private Collider tireCollider;

    public pulloutTire zone;

    public AudioSource zonaClip;

    public LevelChangerScript theChangist;

    public AudioMixerSnapshot fadeIn;
    public AudioMixerSnapshot fadeOut;

    // Use this for initialization
    void Start () {
        tireCollider = tireEject.GetComponent<Collider>();
        handGesture = GameObject.Find("Gesture_Right").GetComponent<Animator>();
        gotoGameZone = GameObject.Find("Gesture_Left").GetComponent<Animator>();

        fadeIn.TransitionTo(1.4f);
        zonaClip = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (rinesAfuera == 4)
        {
            tireCollider.enabled = true;
        }

        if (rinesAfuera == 9)
        {
            tireCollider.enabled = true;
        }

        if (zone.timesPulled == 2)
        {
            tireCollider.enabled = false;
        }

        if (pernosPuestos >= 4)
        {
            fadeOut.TransitionTo(.4f);
            theChangist.FadeToLevel(4);
        }

    
    }

    private void FixedUpdate()
    {

        if (playerPosition.rotation.y == 0)
        {
            inGameZone = true;
        }

        if (playerPosition.rotation.y != 0)
        {
            inGameZone = false;
        }

       
    }

    public void GoToToolZone ()
    {
        if (inGameZone)
        {
        thePlayer.SetBool("toToolZone", true);
        thePlayer.SetBool("toGameZone", false);
            zonaClip.Play();
        }
    }

    public void GoToGameZone ()
    {
        if (inGameZone == false)
        {
        thePlayer.SetBool("toGameZone", true);
        thePlayer.SetBool("toToolZone", false);
            zonaClip.Play();
        }
    }


    public void toolZoneSprite()

    {

        handGesture.SetBool("changeSprite", true);
        gotoGameZone.SetBool("isUp", true);
        gotoGameZone.SetBool("gameZone", false);
    }

    public void gameZoneSprite()

    {

        handGesture.SetBool("changeSprite", false);
        gotoGameZone.SetBool("gameZone", true);

        

    

    }
}
