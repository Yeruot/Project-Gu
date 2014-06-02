using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour {
    private Gu gu;

    public float throwModifier;

	// Use this for initialization
	void Start () {
        gu = Gu.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	    if(gu.IsCarrying() && Input.GetButtonDown("Action")){
            GameObject objectToThrow = gu.holdingObject;
            gu.PutDown();
            objectToThrow.transform.rigidbody.AddForce((transform.forward + transform.up) * throwModifier);
        }
	}
}
