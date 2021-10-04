using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressometer : MonoBehaviour {

    private const float MAX_SPEED_ANGLE = -88;
    public float ZERO_SPEED_ANGLE = 8.2f;

    public Transform needleTransform;

    private float speedMax;
    private float speed;

    public bool hasCompleted;
    public bool hasExploted;

    public bool isPumping;

    public GameObject increaseTire;

    public Collider pmp;

    public GameObject insert;

    public GameObject put;

    bool st;

    public GameObject inflateHere;


    private void Awake()
    {
       // needleTransform = transform.Find("Puntero");
        speed = 0f;
        speedMax = 200f;

    }

    private void Start()
    {
     
        pmp = GameObject.Find("InflateZone").GetComponent<Collider>();
        put.SetActive(false);
    }


    // Update is called once per frame
    void Update () {

        if (needleTransform.rotation.z <= -0.5114431 && needleTransform.rotation.z >= -0.6197789)
        {
            hasCompleted = true;
        }

        else if (needleTransform.rotation.z <= -0.6480535)
        {
            hasCompleted = false;
            hasExploted = true;
        }

        else

        {
            hasExploted = false;
        }

   //   Debug.Log(needleTransform.rotation.z);


        if (isPumping == true)
        {
            increaseTire.SetActive(true);

            speed += Random.Range(30.0f, 100.0f) * Time.deltaTime;
        if (speed > speedMax) speed = speedMax;

            needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
        }

        if (hasCompleted)
        {
            put.SetActive(true);
            StartCoroutine("DownInflate");
        }

        if (hasCompleted == false)
        {
            put.SetActive(false);

        }

        if (hasExploted)
        {
            speed = 0f;
            needleTransform.eulerAngles = new Vector3(0, 0, 10);
          //  st = true;
            isPumping = false;
            pmp.enabled = false;

            insert.GetComponent<Animator>().enabled = true;
            insert.GetComponent<Animator>().SetBool("hasEntered", false);
            insert.GetComponent<Animator>().SetBool("hasEntered2", false);

            inflateHere.SetActive(true);
        }

        if (st == true)
        {

                
        }


      
         
    }

    void FixedUpdate()
    {
 
    }

    public float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;

    }

    IEnumerator DownInflate()
    {
            yield return new WaitForSeconds(.5f);
        inflateHere.SetActive(false);
    }



}
