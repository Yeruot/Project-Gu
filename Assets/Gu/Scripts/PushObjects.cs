using UnityEngine;
using System.Collections;

public class PushObjects : MonoBehaviour {
    public float pushPower;
    
    //On Collision get reference to the current collision object and push it
    //evntually you'll need to check if the interact button is being pressed
    //before pushing the object 
    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3f)
            return;

        if (Input.GetButton("Interact")) {
            Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.velocity = pushDirection * pushPower;
        }
    }
}
