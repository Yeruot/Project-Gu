using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    private Vector3 movementVector;
    private CharacterController charController;
    private float verticalSpeed;

    public float forwardSpeed;
    public float backwardSpeed;
    public float turnSpeed;
    public float gravity;
    public float jumpSpeed;

	// Use this for initialization
	void Start () {
        charController = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        //forward and backward speeds are different
        if (Input.GetAxis("Vertical") > 0)
            movementVector = transform.forward * Input.GetAxis("Vertical") * forwardSpeed;
        else if (Input.GetAxis("Vertical") < 0)
            movementVector = transform.forward * Input.GetAxis("Vertical") * backwardSpeed;
        else
            movementVector = transform.forward * 0;

        if (charController.isGrounded) {
            //No need to apply gravity
            verticalSpeed = 0;
            if (Input.GetKey("space")) {
                verticalSpeed = jumpSpeed;
            }
        }

        verticalSpeed -= gravity * Time.deltaTime;
        movementVector.y = verticalSpeed;
        charController.Move(movementVector * Time.deltaTime);

        charController.Move(movementVector * Time.deltaTime);
	}
}
