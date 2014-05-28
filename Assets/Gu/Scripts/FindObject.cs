using UnityEngine;
using System.Collections;

public class FindObject : MonoBehaviour {
    private RaycastHit hitObject;
    private Rect labelRect = new Rect((Screen.width / 2 - 50), ((Screen.height * 3) / 4 - 50), 100, 100);
    private ToolTipType toolTipType;

    public Vector3 contactPoint { get; set; }
    public Vector3 normal { get; set; }
    public GUIStyle tooltipStyle;

    enum ToolTipType
    {
        None = 0,
        Push = 1,
        PickUp = 2,
    }

	// Use this for initialization
	void Start () {
        toolTipType = ToolTipType.None;

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
            switch (hitObject.transform.gameObject.tag) {
                case "Large Object":
                    toolTipType = ToolTipType.Push;
                    break;
                case "Small Object":
                    toolTipType = ToolTipType.PickUp;
                    break;
                default:
                    print ("Invalid Object Tag for Tooltip");
                    break;
            }
            contactPoint = hitObject.point;
            normal = hitObject.normal;
            Gu.Instance.targetObject = hitObject.transform.gameObject;
        } else {
            toolTipType = ToolTipType.None;
            Gu.Instance.targetObject = null;
        }
	}

    void OnGUI() {
            switch(toolTipType){
                case ToolTipType.Push:
                    GUI.Label(labelRect, "Press E to push", tooltipStyle);                    
                    break;
                case ToolTipType.PickUp:
                    GUI.Label(labelRect, "Press E to pick up", tooltipStyle);
                    break;
                case ToolTipType.None:
                    break;
                default:
                    print("Invalid tool tip type");
                    break;
            }
    }
}
