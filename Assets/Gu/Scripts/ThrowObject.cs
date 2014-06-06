using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour {
    private Gu gu;

    //strength at which we throw an object
    public float throwModifier;

	// Use this for initialization
	void Start () {
        gu = Gu.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        //when we throw an object we first want to put it down
        //then proceed to add the correct velocity to it and
        //throw it
	    if(gu.IsCarrying() && Input.GetButtonDown("Action")){
            GameObject objectToThrow = gu.holdingObject;
            gu.PutDown();
            objectToThrow.transform.rigidbody.AddForce((transform.forward + transform.up) * throwModifier);
        }
	}
}
