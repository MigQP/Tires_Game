using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentTool : MonoBehaviour {

    public Transform leftHandPalm;

    public GameObject tool;

    public GameObject theHand;

    private Rigidbody toolBody;

	// Use this for initialization
	void Start () {
        toolBody = this.gameObject.GetComponent<Rigidbody>();
        leftHandPalm = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
	
	// Update is called once per frame
	void Update () {
  
    }

    public void ParentTool()
    {

        tool.transform.parent = leftHandPalm.transform;
    }

    public void UnparentTool()
    {
    
        tool.transform.parent = null;
    }

    public  void OnCollisionEnter(Collision other)
    {
        theHand = other.gameObject;
        Debug.Log(theHand);
        
    }
}
