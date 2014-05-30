using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Gu gu = Gu.Instance;
        if (gu.targetObject != null) {
            GameObject target = Gu.Instance.targetObject;
            if ((Input.GetButtonDown("Interact")) && ((target != null) || (target != gu.holdingObject))) {
                performAction(target.tag);
            } else if (Input.GetButtonUp("Interact")){
                if (Gu.Instance.targetObject != null)
                    endConcurrentAction(target.tag);
            }
        }
	}

    void performAction(string tag) {
        Gu gu = Gu.Instance;
        switch (tag) {
            case "Large Object":
                gu.StartPush();
                break;
            case "Small Object":
                if (gu.IsCarrying())
                    gu.PutDown();
                else
                    gu.PickUp();
                break;
            default:
                break;
        }
    }

    void endConcurrentAction(string tag) {
        Gu gu = Gu.Instance;
        switch (tag) {
            case "Large Object":
                gu.EndPush();
                break;
            default:
                break;
        }
    }
}
