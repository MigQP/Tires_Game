using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createInflable : MonoBehaviour {


    public GameObject inflado;
    public Transform infe;

  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     
	}

         void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "insert")
        {
            Instantiate(inflado, infe);
            Debug.Log("NUEVAAAAA");
        }
    }

     void OnTriggerEnter(Collider other)
    {
        
    }
}
