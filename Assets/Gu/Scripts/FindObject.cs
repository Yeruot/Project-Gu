using UnityEngine;
using System.Collections;

public class FindObject : MonoBehaviour {
    private RaycastHit hitObject;
    private Rect labelRect = new Rect((Screen.width / 2 - 50), ((Screen.height * 3) / 4 - 50), 100, 100);
    private bool displayTooltip;
    private GUIStyle tooltipStyle;

	// Use this for initialization
	void Start () {
        displayTooltip = false;

        //Setup tooltip label properties for display
        tooltipStyle = new GUIStyle();
        tooltipStyle.alignment = TextAnchor.MiddleCenter;
        tooltipStyle.fontSize = 16;
        tooltipStyle.normal.textColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hitObject, 3f)) {
            displayTooltip = true;
            Gu.Instance.targetObject = hitObject.transform.gameObject;
        } else {
            displayTooltip = false;
            if(Gu.Instance.targetObject != null)
                removeAddedComponent();
            Gu.Instance.targetObject = null;

        }
	}

    void OnGUI() {
        if (displayTooltip) {
            GUI.backgroundColor = Color.blue;
            GUI.Label(labelRect, "Press E to push", tooltipStyle);
        }
    }

    void removeAddedComponent() {
        GameObject target = Gu.Instance.targetObject;
        switch (target.tag) {
            case "Block":
                Destroy(target.GetComponent<PushObject>());
                break;
            default:
                break;
        }
    }
}
