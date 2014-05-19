using UnityEngine;
using System.Collections;

public class PushObjects : MonoBehaviour {
    public float pushPower;
    
    //On Collision get reference to the current collision object and push it
    //evntually you'll need to check if the interact button is being pressed
    //before pushing the object 
    void Update() {
        if (Gu.Instance.targetObject == null)
            return;

        Rigidbody body = Gu.Instance.targetObject.rigidbody;

        if (body == null || body.isKinematic)
            return;

        ThirdPersonController thirdPersonController = transform.GetComponent<ThirdPersonController>();
        Vector3 direction = thirdPersonController.GetDirection();
        if (direction.y < -0.3f)
            return;

        if ((Input.GetButton("Interact")) && thirdPersonController.IsMoving()) {
            Vector3 pushDirection = new Vector3(direction.x, 0, direction.z);
            body.velocity = pushDirection * pushPower;
        }
    }
}
