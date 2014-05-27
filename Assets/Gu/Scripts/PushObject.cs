using UnityEngine;
using System.Collections;

public class PushObject : MonoBehaviour {
    private float moveSpeed;
    private Gu gu;

    void Start() {
        gu = Gu.Instance;
    }

	// Update is called once per frame
	void FixedUpdate () {
        moveSpeed = gu.gameObject.GetComponent<ThirdPersonController>().GetSpeed();
        Rigidbody body = this.rigidbody;

        if (body == null || body.isKinematic)
            return;

        ThirdPersonController thirdPersonController = Gu.Instance.GetComponent<ThirdPersonController>();
        Vector3 direction = thirdPersonController.GetDirection();

        if (thirdPersonController.IsMoving()) {
            Vector3 pushDirection = new Vector3(direction.x, 0.0f, direction.z);
            body.velocity = pushDirection * moveSpeed;
        }
	}
}
