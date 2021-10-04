using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoAgain : MonoBehaviour {

    /*TUTORIAL VIDEO MANAGER*/

    public VideoPlayer theTutorial;

    public bool canMoveOn;

    public GameObject thumbsUpGesture;

    public GameObject thumbsToGo;

     private void Update()
    {
        if (theTutorial.isPlaying == false)
        {
            StartCoroutine("PlayAgainV");
            thumbsUpGesture.SetActive(true);
            thumbsToGo.SetActive(true);
        }

        if (theTutorial.isPlaying == true)
        {

            thumbsUpGesture.SetActive(false);
            thumbsToGo.SetActive(false);
        }


    }


    IEnumerator PlayAgainV()
    {

        yield return new WaitForSeconds(12);
        theTutorial.Play();
    }
}
