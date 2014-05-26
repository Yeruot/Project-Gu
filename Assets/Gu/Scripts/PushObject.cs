using UnityEngine;
using System.Collections;

public class PushObject : MonoBehaviour {
    private float pushPower;


    void Start() {
        switch (this.tag) {
            case "Block":
                pushPower = 1.5f;
                break;
            default:
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        Rigidbody body = this.rigidbody;

        if (body == null || body.isKinematic)
            return;

        ThirdPersonController thirdPersonController = Gu.Instance.GetComponent<ThirdPersonController>();
        Vector3 direction = thirdPersonController.GetDirection();

        if (thirdPersonController.IsMoving()) {
            Vector3 pushDirection = new Vector3(direction.x, 0, direction.z);
            body.velocity = pushDirection * pushPower;
        }
	}
}
