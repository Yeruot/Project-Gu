using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Gu gu = Gu.Instance;
        if (gu.targetObject != null) {
            GameObject target = Gu.Instance.targetObject;
            if ((Input.GetButton("Interact")) && (target != null)) {
                switch (target.tag) {
                    case "Large Object":
                        gu.StartPush();
                        break;
                    case "Small Object":
                        gu.PickUp();
                        break;
                    default:
                        break;
                }
            } else {
                if (Gu.Instance.targetObject != null)
                    removeAddedComponent();
            }
        }
	}

    void removeAddedComponent() {
        Gu gu = Gu.Instance;
        GameObject target = gu.targetObject;
        switch (target.tag) {
            case "Large Object":
                gu.EndPush();
                break;
            case "Small Object":
                gu.PutDown();
                break;
            default:
                break;
        }
    }
}
