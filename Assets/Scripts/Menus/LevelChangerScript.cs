using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour {

    public Animator animator;

    private int levelToLoad;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
            FadeToLevel(2);
	}

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeCpmplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
