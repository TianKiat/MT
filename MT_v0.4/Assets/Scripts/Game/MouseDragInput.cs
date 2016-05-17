// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE:
// Description: MouseDragInput is 
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;

public class MouseDragInput : MonoBehaviour {
	VehicleParent vp;
	Vector3 mouseReference;
	public Transform steeringWheel;
	void Start() {
		vp = GetComponent<VehicleParent>();
	}
	     
	void OnMouseDrag() {
	    Vector3 offset = (Input.mousePosition - Camera.main.WorldToScreenPoint(steeringWheel.position));
	    float steer = Mathf.Clamp(Mathf.RoundToInt(offset.x), -1, 1);
		float accel = Mathf.Clamp(Mathf.RoundToInt(offset.y), -1, 1);
	    Debug.Log("Steer "+ steer + " Accel "+ accel);
	    vp.SetSteer(steer);
	    vp.SetAccel(accel);
	}

	void OnMouseUp() {
		vp.SetSteer(0);
	    vp.SetAccel(0);
	}
}
