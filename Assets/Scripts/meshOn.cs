using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshOn : MonoBehaviour {

    /*WHEN THE TIRE IS PUT INSIDE THERES IS ANOTHER ONE WHICH HAS THE INCREASE SCALE EFFECT
      THIS SCRIPT CHANGES ONE FOR THE OTHER*/


    public AudioSource insertionSoundClip;

    public MeshRenderer tireJafFull;
    public MeshRenderer rinJafFull;

    public  int n;
    public GameObject inflaa;
         
    private Animator enterTruck;

	// Use this for initialization
	void Awake () {
       
        enterTruck = this.gameObject.GetComponent<Animator>();
        insertionSoundClip = this.GetComponent<AudioSource>();



        tireJafFull.enabled = false;
        rinJafFull.enabled = false;
        enterTruck.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
      if (enterTruck.GetBool("hasEntered2") == false)
        {
            rinJafFull.enabled = false;
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "llantaRepuesto")
        {
            enterTruck.SetBool("hasEntered", true);
            enterTruck.SetBool("hasEntered2", true);
            insertionSoundClip.Play();


            tireJafFull.enabled = true;
            rinJafFull.enabled = true;
        }

        if (other.gameObject.tag == "Player")
        {
           // StartCoroutine("Offer");
        }
        if (other.gameObject.tag == "creation")
        {

            //      replacement.enabled = true;
            //      rin2.enabled = true;
            //      infff.enabled = true;
            StartCoroutine("Offer");
            n++;
            if (n == 1)
            {
                Instantiate(inflaa);
             
            }

   
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EditorOnly")
        {
       
        //    replacement.enabled = false;

            tireJafFull.enabled = false;
            rinJafFull.enabled = false;

        }
        if (other.gameObject.tag == "creation")
        {
            n = 0;
        }

    }


    IEnumerator Offer()
    {

        yield return new WaitForSeconds(2);
      //  replacement.enabled = false;
        tireJafFull.enabled = false;
    }
}
