using UnityEngine;
using System.Collections;

public class PushObject : MonoBehaviour {
    private float moveSpeed;
    private Gu gu;

    void Start() {
        gu = Gu.Instance;
    }

	// Fixed Update is called once per physics frame 
	void FixedUpdate () {
        moveSpeed = gu.gameObject.GetComponent<ThirdPersonController>().GetSpeed();
        Rigidbody body = this.rigidbody;

        if (body == null || body.isKinematic)
            return;

        ThirdPersonController thirdPersonController = Gu.Instance.GetComponent<ThirdPersonController>();
        Vector3 direction = thirdPersonController.GetDirection();

	//only move the object if the player is also moving
        if (thirdPersonController.IsMoving()) {
	    //get the diection of the playe and add velocity of the player
	    //to that block in the same direction as the player
            Vector3 pushDirection = new Vector3(direction.x, 0.0f, direction.z);
            body.velocity = pushDirection * moveSpeed;
        }
	}
}
