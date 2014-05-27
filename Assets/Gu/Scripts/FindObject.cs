using UnityEngine;
using System.Collections;

public class FindObject : MonoBehaviour {
    private RaycastHit hitObject;
    private Rect labelRect = new Rect((Screen.width / 2 - 50), ((Screen.height * 3) / 4 - 50), 100, 100);
    private bool displayTooltip;

    public Vector3 contactPoint { get; set; }
    public Vector3 normal { get; set; }
    public GUIStyle tooltipStyle;

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
            contactPoint = hitObject.point;
            normal = hitObject.normal;
            Gu.Instance.targetObject = hitObject.transform.gameObject;
        } else {
            displayTooltip = false;
            Gu.Instance.targetObject = null;

        }
	}

    void OnGUI() {
        if (displayTooltip) {
            GUI.Label(labelRect, "Press E to push", tooltipStyle);
        }
    }
}
