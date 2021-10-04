using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTool : MonoBehaviour {

    public GameObject theTool;

    private Pistola actualTool;
    private palanca actualPalanca;
    private Inflador actualInfladora;
    private Repuesto actualLlanta;

    public Animator palancaAnim;

    public Animator llantaAnim;


    public scaleLerper theIncreaser;

	// Use this for initialization
	void Start () {
    
        

    }
	
	// Update is called once per frame
	void Update () {
        actualTool = (Pistola)FindObjectOfType(typeof(Pistola));
        actualPalanca = (palanca)FindObjectOfType(typeof(palanca));
        actualInfladora = (Inflador)FindObjectOfType(typeof(Inflador));
        actualLlanta = (Repuesto)FindObjectOfType(typeof(Repuesto));
        theIncreaser = (scaleLerper)FindObjectOfType(typeof(scaleLerper));


        palancaAnim = actualPalanca.gameObject.GetComponent<Animator>();

    }

    public void NewPistola ()
    {
        Destroy(actualTool.gameObject);
        Instantiate(theTool);
    }

    public void NewPalanca ()
    {
        Destroy(actualPalanca.gameObject);
        Instantiate(theTool);  
    }

    public void NewInfladora()
    {
        Destroy(actualInfladora.gameObject);
        Instantiate(theTool);
    }

    public void NewLlanta()
    {
        Destroy(actualLlanta.gameObject);
        Instantiate(theTool);
        llantaAnim.SetBool("hasEntered2", false);
        Destroy(theIncreaser.gameObject);
    }

    IEnumerator ByeBye ()
    {

        yield return new WaitForSeconds(1);
        Destroy(actualPalanca.gameObject);
        Instantiate(theTool);
    }



}
