using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infl : MonoBehaviour {

    //SWAP BETWEEN STATIC TIRE AND INFLABLE TIRE

    public MeshRenderer inflada;

    public SkinnedMeshRenderer carcasa;

	// Use this for initialization
	void Start () {
       // inflada.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "insert")
        {
         //   StartCoroutine("Example");
            inflada.enabled = true;
        }
    }

    IEnumerator Example()
    {
  
        yield return new WaitForSeconds(2);
        carcasa.enabled = false;
    }
}
