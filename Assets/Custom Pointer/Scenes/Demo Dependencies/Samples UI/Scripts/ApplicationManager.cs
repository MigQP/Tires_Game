using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.Video;

public class ApplicationManager : MonoBehaviour {

    public AudioMixerSnapshot theFader;

 

     void Start()
    {
        theFader.TransitionTo(1.2f);
    }



    public void Quit () 
	{
        StartCoroutine("WaitForSound");
	}

    IEnumerator WaitForSound()
    {
        
            yield return new WaitForSeconds(1);
        		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
       
    }



}
