using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour
{

    // Update is called once per frame
    void Update() {
        Gu gu = Gu.Instance;
        if (Input.GetButtonDown("Interact")) {
            if (gu.IsCarrying())
                performAction(gu.holdingObject.tag);
            else if (gu.targetObject != null)
                performAction(gu.targetObject.tag);
        } else if (Input.GetButtonUp("Interact")) {
            if (gu.targetObject != null)
                endConcurrentAction(gu.targetObject.tag);
        }
    }

    void performAction(string tag) {
        Gu gu = Gu.Instance;
        switch (tag) {
            case "Large Object":
                gu.StartPush();
                break;
            case "Small Object":
                if (gu.IsCarrying()) {
                    print("butts");
                    gu.PutDown();
                } else {
                    print("dicks");
                    gu.PickUp();
                }
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
