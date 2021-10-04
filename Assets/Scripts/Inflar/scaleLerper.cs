using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleLerper : MonoBehaviour {

    public bool shouldLerp;
    public bool hasCreated;


    public float timeStartedLerping;
    public float lerpTime;

    public Vector3 minScale;
    public Vector3 maxScale;
    public Vector3 startScale;

    public MeshRenderer tireLook;


    public Pressometer checkPressure;

    public GameObject repuestoLlanta;
  


    public GameObject newLlanta;

    public GameObject inflable;

    int n;

    private AudioSource burstSound;



    public void StartLerping ()
    {
        timeStartedLerping = Time.time;
        


        shouldLerp = true;
    }


    void Start()
    { 
        checkPressure = GameObject.FindGameObjectWithTag("GameController").GetComponent<Pressometer>();
        burstSound = GameObject.FindGameObjectWithTag("reve").GetComponent<AudioSource>();
  

    }

    private void OnEnable ()
    {
      
    }

    void FixedUpdate()
    {

        minScale = this.transform.localScale;
        if (shouldLerp)
        {
           

               transform.localScale = Lerp(minScale, maxScale, lerpTime);
            
        }



        if (checkPressure.hasExploted)

        {
            
            
            
         
            hasCreated = true;
            n++;


            if (hasCreated && n == 1)
            {
                Instantiate(newLlanta);
        
                

            }


            hasCreated = false;


            burstSound.Play();
            Destroy(this.gameObject);


        }

        if (checkPressure.hasExploted == false && n == 1)
        {
            minScale = startScale;
        }
    }



    public Vector3 Lerp (Vector3 start, Vector3 end, float lerpTime = 10)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }


}
