using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class sceneOperator : MonoBehaviour {

    public int timesSwipped;

    public Animator[] thePanels;

    public LevelChangerScript theTransition;

    public AudioMixerSnapshot theOut;

    public bool hasSwipped;

    public bool hasSecondSwipped;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hasSwipped == true)
        {
        
            thePanels[0].SetTrigger("goToSecond");
            timesSwipped++;
            hasSwipped = false;
        }


        
 



    }

    public void ToRepairGame()
    {
        SceneManager.LoadScene(1);
    }

    public void swapTime ()
    {
        timesSwipped++;

        if (timesSwipped == 1)
        {
         //   thePanels[0].SetTrigger("goToSecond");
        }

        if (timesSwipped == 2)
        {
         //   thePanels[1].SetTrigger("goToThird");
        }

        if (timesSwipped == 3)
        {
           // StartCoroutine("ByeTutorial");
        }
    }

    IEnumerator ByeTutorial()
    {
        
            yield return new WaitForSeconds(.5f);
        theOut.TransitionTo(.2f);
        theTransition.FadeToLevel(2);
    }


    public void hasSwippedTrue()
    {

            hasSwipped = true;
    }


    public void hasSwippedFalse()
    {

        hasSwipped = false;
    }


    public void has2ndSwippedTrue()
    {
     
        hasSecondSwipped = true;
    }


    public void has2ndSwippedFalse()
    {
       
        hasSecondSwipped = false;
    }

}






